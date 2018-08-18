from bs4 import BeautifulSoup
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
