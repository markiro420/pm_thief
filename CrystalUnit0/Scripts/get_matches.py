from bs4 import BeautifulSoup, Tag
import sys
from delivery_manager import *
from sport_hierarchy import *
from utils import MyEncoder
import json


def get_matches(soup: BeautifulSoup, sport: str):
    if sport.lower() == 'football':
        return get_matches_football(soup)
    else:
        return []


def get_matches_football(soup: BeautifulSoup):
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
            matches.append(get_match_data_football(raw_match))

    nice_matches = []
    for match in matches:
        pseudo_class = {}
        for i, col in enumerate(match):
            field = meta_names[i].split()
            field = ''.join([field[0].lower()] + [w.capitalize() for w in field[1:]])
            if field == 'date':
                pseudo_class['date'] = col[0] + ' ' + col[1]
            elif field == 'event':
                pseudo_class['teamFirst'] = col[0]
                pseudo_class['teamSecond'] = col[1]
            elif len(col) == 1:
                pseudo_class[field] = col[0]
            elif len(col) == 2:
                pseudo_class[field+'First'] = col[0]
                pseudo_class[field+'Second'] = col[1]
        nice_matches.append(pseudo_class)
    return nice_matches


def get_match_data_football(raw_match: [Tag]):
    raw_match = raw_match.tr

    data_cols = list(raw_match.find_all("td"))
    match_data = []

    # if len(data_cols) != 17:
    #     print('wtf?')
    for i, col in enumerate(data_cols):
        match_data.append(list(col.stripped_strings))
    return match_data


if __name__ == "__main__":
    if len(sys.argv) > 1:
        in_uuid = sys.argv[1]
        sport = sys.argv[2]
        html_text = read_file(in_uuid)
        soup = html_to_soup(html_text)
        raw_matches = get_matches(soup, sport)
        write_file(json.dumps(raw_matches))

