from bs4 import BeautifulSoup, Tag
import sys
from delivery_manager import *
from sport_hierarchy import *
from utils import MyEncoder
import json


def get_raw_matches(soup: BeautifulSoup):
    raw_table = soup.find(class_="dt twp", recursive=True)

    meta_names = []
    for col in raw_table.find("tbody").tr.find_all("th"):
        name = col.attrs.get("title")
        if name is None:
            meta_names.append(col.get_text())
        else:
            meta_names.append(col.attrs['title'])

    row_matches = list(raw_table.find_all("tbody", class_=lambda c: (c == "row1" or c == "row2")))

    matches = []

    for raw_match in row_matches:
        try:
            classes = dict(raw_match.attrs)["class"]
        except KeyError:
            classes = []
        if "props" not in classes:
            matches.append(get_match_data(raw_match))
    return meta_names, matches


def get_match_data(raw_match: [Tag]):
    raw_match = raw_match.tr

    data_cols = list(raw_match.find_all("td"))
    match_data = []
    for i, col in enumerate(data_cols):
        match_data.append(col.get_text())

    return match_data


if __name__ == "__main__":
    if len(sys.argv) > 1:
        in_uuid = sys.argv[1]
        html_text = read_file(in_uuid)
        soup = html_to_soup(html_text)
        raw_matches = get_raw_matches(soup)
        write_file(json.dump(raw_matches))
    else:
        with open('test.csv', 'a', encoding='utf8') as file:
            sh = get_sport_hierarchy(download_html_page_soup("https://www.parimatch.com/en/sport/futbol/liga-nacijj-uefa"))
            for sport in sh:
                i = 0
                for league in sport.leagues:
                    bs = download_html_page_soup(league.link)
                    try:
                        meta_names, _ = get_raw_matches(bs)
                    except:
                        meta_names = []
                    try:
                        file.write(sport.name + ','+league.name + ','+",".join(meta_names) + '\n')
                        print(sport.name +' ' + str(i) + '/' + str(len(sport.leagues)))
                    except:
                        with open('errors.csv', 'a', encoding='utf8') as f:
                            f.write(sport.name + ' ' + league.link)
                            print('error')
                    i += 1

                print()

