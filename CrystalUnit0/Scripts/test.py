from bs4 import BeautifulSoup, Tag
import sys
from delivery_manager import *
from sport_hierarchy import *
from utils import MyEncoder
import json

bs = download_html_page_soup("https://www.parimatch.com/en/sport/futbol/liga-nacijj-uefa")

