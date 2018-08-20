from bs4 import BeautifulSoup
import sys
import delivery_manager
import json


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


in_uuid = sys.argv[1]
html_text = delivery_manager.read_file(in_uuid)
soup = delivery_manager.html_to_soup(html_text)
hrchy = get_sport_hierarchy(soup)
print(delivery_manager.write_file(json.dumps(hrchy)))
