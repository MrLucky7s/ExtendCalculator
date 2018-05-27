import clr

import System
clr.AddReference('System.Windows.Forms')
from System.Windows.Forms import *
clr.AddReference('System.Drawing')
from System.Drawing import Point

import re
import math
import operator


def Square(sender, args):
    if (operator.and_(len(sender.Tag.txtA.Text)>0,(re.search('[a-zA-Z]+',sender.Tag.txtA.Text)==None))): #provjerava nalaze li se brojevi u text boxu i nakon toga provodi operacije
        sender.Tag.txtResult.Text = str(math.pow(float(sender.Tag.txtA.Text),2))
    elif(operator.and_(len(sender.Tag.txtB.Text)>0,(re.search('[a-zA-Z]+',sender.Tag.txtB.Text)==None))):
        sender.Tag.txtResult.Text = str(math.pow(float(sender.Tag.txtB.Text),2))
    else:
        sender.Tag.txtResult.Text ="" #ako nema brojeva u text boxu result istaje prazan

def LoadScript(frm): #Provjerava postoji li vec istoimena funkcija i dodaje ju ako ne
    Result=True
    for items in frm.addedOperationsToolStripMenuItem.DropDownItems:     
        if (items.Text=='Square'):
             System.Windows.Forms.MessageBox.Show('Operation already exists!')
             Result=False
        else:
            pass
    if Result:
        name='Square'
        menuItem= ToolStripMenuItem(Text=name)
        frm.addedOperationsToolStripMenuItem.DropDownItems.Add(menuItem) 
        menuItem.Tag=frm
        menuItem.Click+= Square
		