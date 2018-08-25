class League:
    def __init__(self, name, link):
        self.name = name
        if link.find("https://www.parimatch.com") == -1:
            self.link = "https://www.parimatch.com" + link
        else:
            self.link = link


class Sport:
    def __init__(self, name, leagues):
        self.name = name
        self.leagues = leagues
