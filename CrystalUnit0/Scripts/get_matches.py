from bs4 import BeautifulSoup, Tag
import sys
from delivery_manager import *


def get_raw_matches(soup: BeautifulSoup):
    raw_table = soup.find(class_="dt twp", recursive=True)
    row_matches = list(raw_table.find_all("tbody", class_=lambda c: c == "row1" or c == "row2"))

    raw_matches = []

    for raw_match in row_matches:
        try:
            classes = dict(raw_match.attrs)["class"]
        except KeyError:
            classes = []
        if "props" not in classes:
            raw_matches.append(raw_match)
    return raw_matches


def get_match_data(raw_match: [Tag]):
    raw_match = raw_match.tr

    data_cols = raw_match.find_all("td")


bs = download_html_page_soup("https://www.parimatch.com/en/sport/futbol/liga-chempionov-uefa")
get_raw_matches(bs)