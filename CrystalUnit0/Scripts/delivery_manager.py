from bs4 import BeautifulSoup

from urllib.request import *
import uuid



def html_to_soup(html: str):
    return BeautifulSoup(html, 'html5lib')


def read_file(_uuid):
    with open(_uuid, 'r', encoding='utf-8') as fl:
        return fl.read()


def write_file(data):
    _uuid = str(uuid.uuid4())
    with open(_uuid, 'w', encoding='utf-8') as fl:
        fl.write(str(data))
    return _uuid

#Делаю питон самодостаточным
def download_html_page_soup(url: str):
    soup = BeautifulSoup(download_html_page(url), 'html5lib')
    return soup


def download_html_page(url: str):
    req = Request(url, headers={"User-Agent": "Mozilla/5.0 (X11; U; Linux i686) Gecko/20071127 Firefox/2.0.0.11"})
    res = urlopen(req)
    return res.read()#.decode(errors='replace')