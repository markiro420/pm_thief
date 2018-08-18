from bs4 import BeautifulSoup
import sys
import os
import uuid


def get_sport_hierarchy(soup: BeautifulSoup):
    sports_div = soup.find(id="lobbySportsHolder")
    raw_sports = sports_div.find_all("li", recursive=False)

    hierarchy = {}
    for raw_sport in raw_sports:
        sport_name = raw_sport.a.get_text().strip()
        raw_leagues = raw_sport.ul.find_all("li", recursive=False)
        hierarchy[sport_name] = []
        for rl in raw_leagues:
            league_name = rl.a.get_text().strip()
            league_link = 'https://www.parimatch.com/' + rl.a['href']
            hierarchy[sport_name].append((league_name, league_link))
    return hierarchy


def html_to_soup(html: str):
    return BeautifulSoup(html, 'html5lib')


if_uuid = sys.argv[1]
if_uuid = os.path.join(r'../../Scripts', if_uuid)
with open(if_uuid, 'r', encoding='utf-8') as fl:
    html_text = fl.read()
soup = html_to_soup(html_text)
hrchy = get_sport_hierarchy(soup)
# print(hrchy)

of_uuid = str(uuid.uuid4())
with open(os.path.join(r'../../Scripts', of_uuid), 'w', encoding='utf-8') as fl:
    fl.write(str(hrchy))
print(of_uuid)
