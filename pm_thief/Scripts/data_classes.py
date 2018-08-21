class League:
    def __init__(self, league_name, link):
        self.league_name = league_name
        self.link = "https://www.parimatch.com" + link


class Sport:
    def __init__(self, name, leagues):
        self.name = name
        self.leagues = leagues
