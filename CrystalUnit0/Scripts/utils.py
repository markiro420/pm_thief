from json import JSONEncoder
import sys


class MyEncoder(JSONEncoder):
        def default(self, o):
            return o.__dict__
