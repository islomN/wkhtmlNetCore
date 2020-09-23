import os
import sys

import pdfkit


def generatePdf(type, htmlSrc, name, dir = "."):
    options = {
         'page-size': 'Letter',
         'margin-top': '0.0in',
         'margin-right': '0.0in',
         'margin-bottom': '0.0in',
         'margin-left': '0.0in',
         'encoding': 'UTF-8',
         'quiet': ''
    }
    if(os.path.isdir(dir) is False):
        os.mkdir(dir)

    fileName = dir + "/" + name + ".pdf"
    if(os.path.isfile(fileName)):
        os.remove(fileName)

    if(type == "-url"):
        res = pdfkit.from_url(htmlSrc, fileName , options=options)
    elif (type == "-file"):
        res = pdfkit.from_file(htmlSrc, fileName, options=options)
    else:
        res = pdfkit.from_string(htmlSrc, fileName, options=options)

    print(res)


generatePdf(sys.argv[1], sys.argv[2], sys.argv[3], sys.argv[4])

