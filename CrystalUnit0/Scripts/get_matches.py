from bs4 import BeautifulSoup, Tag
import sys
from delivery_manager import *
from sport_hierarchy import *
from utils import MyEncoder
import json


def get_raw_matches(soup: BeautifulSoup):
    raw_table = soup.find(class_="dt twp", recursive=True)
    row_matches = list(raw_table.find_all("tbody", class_=lambda c: c == "row1" or c == "row2"))

    matches = []

    for raw_match in row_matches:
        try:
            classes = dict(raw_match.attrs)["class"]
        except KeyError:
            classes = []
        if "props" not in classes:
            matches.append(get_match_data(raw_match))
    return matches


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