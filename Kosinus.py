import clr

import System
clr.AddReference('System.Windows.Forms')
from System.Windows.Forms import *
clr.AddReference('System.Drawing')
from System.Drawing import Point

import re
import math
import operator


def Cosine(sender, args):
    if (operator.and_(len(sender.Tag.txtA.Text)>0,(re.search('[a-zA-Z]+',sender.Tag.txtA.Text)==None))):
        sender.Tag.txtResult.Text = str(math.cos(float(sender.Tag.txtA.Text)))
    elif(operator.and_(len(sender.Tag.txtB.Text)>0,(re.search('[a-zA-Z]+',sender.Tag.txtB.Text)==None))):
        sender.Tag.txtResult.Text = str(math.cos(float(sender.Tag.txtB.Text)))
    else:
        sender.Tag.txtResult.Text =""

def LoadScript(frm):
    Result=True
    for items in frm.addedOperationsToolStripMenuItem.DropDownItems:     
        if (items.Text=='Cosine'):
             System.Windows.Forms.MessageBox.Show('Operation already exists!')
             Result=False
        else:
            pass
    if Result:
        name='Cosine'
        menuItem= ToolStripMenuItem(Text=name)
        frm.addedOperationsToolStripMenuItem.DropDownItems.Add(menuItem) 
        menuItem.Tag=frm
        menuItem.Click+= Cosine