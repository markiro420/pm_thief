from bs4 import BeautifulSoup
import sys
import delivery_manager
from data_classes import League, Sport
import json


def get_sport_hierarchy(soup: BeautifulSoup):
    sports_div = soup.find(id="lobbySportsHolder")
    raw_sports = sports_div.find_all("li", recursive=False)

    hierarchy = []
    for raw_sport in raw_sports:
        sport_name = raw_sport.a.get_text().strip()
        raw_leagues = raw_sport.ul.find_all("li", recursive=False)
        leagues = []
        for rl in raw_leagues:
            league_name = rl.a.get_text().strip()
            league_link = 'https://www.parimatch.com/' + rl.a['href']
            leagues.append(League(league_name, league_link))
        hierarchy.append(Sport(sport_name, leagues))
    return hierarchy


if __name__ == "__main__":
    if len(sys.argv) > 1:
        in_uuid = sys.argv[1]
        html_text = delivery_manager.read_file(in_uuid)
        bs = delivery_manager.html_to_soup(html_text)
        sh = [MyEncoder().encode(sport) for sport in get_sport_hierarchy(bs)]
        delivery_manager.write_file(json.dump(sh))
