/*
 * Created by SharpDevelop.
 * User: apal
 * Date: 24-06-2014
 * Time: 10:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebDriverWrapper;
using System.Drawing;
using UIAccess.WebControls;

namespace UIAccess
{
	/// <summary>
	/// Description of Utility.
	/// </summary>
	public static class Utility
    {
        internal static WebControl GetWebControlFromIContol(IControl aControl, Browser aBrowser, Locator aLocator, ControlType aConrolType)
        {
            WebControl aWebControl = null;
            
            if (aConrolType == ControlType.Button)
            {
                WebButton aWebButton = new WebButton(aBrowser, aLocator);
                aWebButton.Control = aControl;
                aWebControl = aWebButton;
            }

            if (aConrolType == ControlType.EditBox)
            {
                WebEditBox aWebEditBox = new WebEditBox(aBrowser, aLocator);
                aWebEditBox.Control = aControl;
                aWebControl = aWebEditBox;
            }
            
            if (aConrolType == ControlType.Custom)
            {
                aWebControl = new WebControl(aBrowser, aLocator);
                aWebControl.Control = aControl;
                //aWebControl = aWebEditBox;
            }
            if (aConrolType == ControlType.Calender)
            {
                WebCalender aWebCalender = new WebCalender(aBrowser, aLocator);
                aWebCalender.Control = aControl;
                aWebControl = aWebCalender;
            }
            
            if (aConrolType == ControlType.ComboBox)
            {
                WebComboBox aWebComboBox = new WebComboBox(aBrowser, aLocator);
                aWebComboBox.Control = aControl;
                aWebControl = aWebComboBox;
            }

            if (aConrolType == ControlType.CheckBox)
            {
                WebCheckBox aWebCheckBox = new WebCheckBox(aBrowser, aLocator);
                aWebCheckBox.Control = aControl;
                aWebControl = aWebCheckBox;
            }

            if (aConrolType == ControlType.Dialog)
            {
                WebDialog aWebDialog = new WebDialog(aBrowser, aLocator);
                aWebDialog.Control = aControl;
                aWebControl = aWebDialog;
            }

            if (aConrolType == ControlType.Frame)
            {
                WebFrame aWebFrame = new WebFrame(aBrowser, aLocator);
                aWebFrame.Control = aControl;
                aWebControl = aWebFrame;
            }

            if (aConrolType == ControlType.Image)
            {
                WebImage aWebImage = new WebImage(aBrowser, aLocator);
                aWebImage.Control = aControl;
                aWebControl = aWebImage;
            }

            if (aConrolType == ControlType.Label)
            {
                WebLabel aWebLabel = new WebLabel(aBrowser, aLocator);
                aWebLabel.Control = aControl;
                aWebControl = aWebLabel;
            }

            if (aConrolType == ControlType.Link)
            {
                WebLink aWebLink = new WebLink(aBrowser, aLocator);
                aWebLink.Control = aControl;
                aWebControl = aWebLink;
            }

            if (aConrolType == ControlType.ListBox)
            {
                WebListBox aWebListBox = new WebListBox(aBrowser, aLocator);
                aWebListBox.Control = aControl;
                aWebControl = aWebListBox;
            }

            if (aConrolType == ControlType.Page)
            {
                WebPage aWebPage = new WebPage(aBrowser, aLocator);
                aWebPage.Control = aControl;
                aWebControl = aWebPage;
            }

            if (aConrolType == ControlType.RadioButton)
            {
                WebRadioButton aWebRadioButton = new WebRadioButton(aBrowser, aLocator);
                aWebRadioButton.Control = aControl;
                aWebControl = aWebRadioButton;
            }

            if (aConrolType == ControlType.SpanArea)
            {
                WebSpanArea aWebSpanArea = new WebSpanArea(aBrowser, aLocator);
                aWebSpanArea.Control = aControl;
                aWebControl = aWebSpanArea;
            }

            if (aConrolType == ControlType.WebTable)
            {
                WebTable aWebTable = new WebTable(aBrowser, aLocator);
                aWebTable.Control = aControl;
                aWebControl = aWebTable;
            }

            if (aConrolType == ControlType.WebRow)
            {
                WebRow aWebRow = new WebRow(aBrowser, aLocator);
                aWebRow.Control = aControl;
                aWebControl = aWebRow;
            }

            if (aConrolType == ControlType.WebCell)
            {
                WebCell aWebCell = new WebCell(aBrowser, aLocator);
                aWebCell.Control = aControl;
                aWebControl = aWebCell;
            }
            
            
            return aWebControl;
        }

        internal static List<WebControl> GetWebControlsFromIControlList(List<IControl> aIControlList, Browser aBrowser, Locator aLocator,ControlType aConrolType)
        {
            List<WebControl> aWebControlList = new List<WebControl>();

            foreach (IControl aControl in aIControlList)
            {
                aWebControlList.Add(GetWebControlFromIContol(aControl, aBrowser, aLocator, aConrolType));               
            }

            return aWebControlList;
        }
        
    }
	
	
		
}
