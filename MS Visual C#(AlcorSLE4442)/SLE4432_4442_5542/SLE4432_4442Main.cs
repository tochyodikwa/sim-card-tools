
/************************************************************************||                  A L C O R   M I C R O,  C O R P.                      ||                                                                        ||         This source code is classified as confidential and             ||         contains trade secrets owned by Alcor Micro, Corp.             ||                                                                        ||                         (C)Copyright 2013                              ||                         Alcor Micro, Corp.                             ||                        All rights reserved.                            ||************************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

namespace SLE4432_4442
{
	/// <summary>
	/// Summary description for SLE4432_4442.
	/// </summary>
	public class SLE4432_4442Main : System.Windows.Forms.Form
	{	
		// variable declaration
		int G_hContext;		//card reader context handle
		int hCard;			//card connection handle
		int ActiveProtocol, retcode;  
		string rreader, tmpStr;  
		byte[] SendBuff = new byte[262];
		byte[] RecvBuff = new byte[262];
		bool ConnActive;
		int SendBuffLen, RecvBuffLen;
		
		private System.Windows.Forms.ComboBox cbReader;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox fCardType;
		private System.Windows.Forms.RadioButton SLE4432;
		private System.Windows.Forms.RadioButton SLE4442;
		private System.Windows.Forms.Button bInit;
		private System.Windows.Forms.Button bConnect;
		private System.Windows.Forms.GroupBox fFunction;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tAdd;
		private System.Windows.Forms.TextBox tLen;
		private System.Windows.Forms.TextBox tData;
		private System.Windows.Forms.Button bErrCtr;
		private System.Windows.Forms.Button bWriteProt;
		private System.Windows.Forms.Button bSubmit;
		private System.Windows.Forms.Button bRead;
		private System.Windows.Forms.Button bWrite;
		private System.Windows.Forms.Button bChange;
		private System.Windows.Forms.Button bReset;
		private System.Windows.Forms.Button bQuit;
		private System.Windows.Forms.ListBox lstOutput;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SLE4432_4442Main()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SLE4432_4442Main));
            this.cbReader = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fCardType = new System.Windows.Forms.GroupBox();
            this.SLE4442 = new System.Windows.Forms.RadioButton();
            this.SLE4432 = new System.Windows.Forms.RadioButton();
            this.bInit = new System.Windows.Forms.Button();
            this.bConnect = new System.Windows.Forms.Button();
            this.fFunction = new System.Windows.Forms.GroupBox();
            this.bChange = new System.Windows.Forms.Button();
            this.bWrite = new System.Windows.Forms.Button();
            this.bRead = new System.Windows.Forms.Button();
            this.bSubmit = new System.Windows.Forms.Button();
            this.bWriteProt = new System.Windows.Forms.Button();
            this.bErrCtr = new System.Windows.Forms.Button();
            this.tData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tLen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bReset = new System.Windows.Forms.Button();
            this.bQuit = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.fCardType.SuspendLayout();
            this.fFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbReader
            // 
            this.cbReader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReader.Location = new System.Drawing.Point(134, 17);
            this.cbReader.Name = "cbReader";
            this.cbReader.Size = new System.Drawing.Size(192, 22);
            this.cbReader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Reader";
            // 
            // fCardType
            // 
            this.fCardType.Controls.Add(this.SLE4442);
            this.fCardType.Controls.Add(this.SLE4432);
            this.fCardType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fCardType.Location = new System.Drawing.Point(29, 52);
            this.fCardType.Name = "fCardType";
            this.fCardType.Size = new System.Drawing.Size(163, 94);
            this.fCardType.TabIndex = 2;
            this.fCardType.TabStop = false;
            this.fCardType.Text = "Card Type";
            // 
            // SLE4442
            // 
            this.SLE4442.Location = new System.Drawing.Point(19, 60);
            this.SLE4442.Name = "SLE4442";
            this.SLE4442.Size = new System.Drawing.Size(135, 18);
            this.SLE4442.TabIndex = 1;
            this.SLE4442.Text = "SLE 4442/5542";
            this.SLE4442.Click += new System.EventHandler(this.SLE4442_Click);
            // 
            // SLE4432
            // 
            this.SLE4432.Location = new System.Drawing.Point(19, 26);
            this.SLE4432.Name = "SLE4432";
            this.SLE4432.Size = new System.Drawing.Size(125, 26);
            this.SLE4432.TabIndex = 0;
            this.SLE4432.Text = "SLE 4432";
            this.SLE4432.Click += new System.EventHandler(this.SLE4432_Click);
            // 
            // bInit
            // 
            this.bInit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bInit.Location = new System.Drawing.Point(221, 60);
            this.bInit.Name = "bInit";
            this.bInit.Size = new System.Drawing.Size(96, 26);
            this.bInit.TabIndex = 3;
            this.bInit.Text = "&Initialize";
            this.bInit.Click += new System.EventHandler(this.bInit_Click);
            // 
            // bConnect
            // 
            this.bConnect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bConnect.Location = new System.Drawing.Point(221, 103);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(96, 26);
            this.bConnect.TabIndex = 4;
            this.bConnect.Text = "&Connect";
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // fFunction
            // 
            this.fFunction.Controls.Add(this.bChange);
            this.fFunction.Controls.Add(this.bWrite);
            this.fFunction.Controls.Add(this.bRead);
            this.fFunction.Controls.Add(this.bSubmit);
            this.fFunction.Controls.Add(this.bWriteProt);
            this.fFunction.Controls.Add(this.bErrCtr);
            this.fFunction.Controls.Add(this.tData);
            this.fFunction.Controls.Add(this.label4);
            this.fFunction.Controls.Add(this.tLen);
            this.fFunction.Controls.Add(this.label3);
            this.fFunction.Controls.Add(this.tAdd);
            this.fFunction.Controls.Add(this.label2);
            this.fFunction.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fFunction.Location = new System.Drawing.Point(19, 164);
            this.fFunction.Name = "fFunction";
            this.fFunction.Size = new System.Drawing.Size(298, 215);
            this.fFunction.TabIndex = 5;
            this.fFunction.TabStop = false;
            this.fFunction.Text = "Functions";
            // 
            // bChange
            // 
            this.bChange.Enabled = false;
            this.bChange.Location = new System.Drawing.Point(163, 181);
            this.bChange.Name = "bChange";
            this.bChange.Size = new System.Drawing.Size(106, 25);
            this.bChange.TabIndex = 11;
            this.bChange.Text = "C&hange Code";
            this.bChange.Click += new System.EventHandler(this.bChange_Click);
            // 
            // bWrite
            // 
            this.bWrite.Location = new System.Drawing.Point(163, 146);
            this.bWrite.Name = "bWrite";
            this.bWrite.Size = new System.Drawing.Size(106, 26);
            this.bWrite.TabIndex = 10;
            this.bWrite.Text = "&Write";
            this.bWrite.Click += new System.EventHandler(this.bWrite_Click);
            // 
            // bRead
            // 
            this.bRead.Location = new System.Drawing.Point(163, 112);
            this.bRead.Name = "bRead";
            this.bRead.Size = new System.Drawing.Size(106, 26);
            this.bRead.TabIndex = 9;
            this.bRead.Text = "Re&ad";
            this.bRead.Click += new System.EventHandler(this.bRead_Click);
            // 
            // bSubmit
            // 
            this.bSubmit.Enabled = false;
            this.bSubmit.Location = new System.Drawing.Point(38, 181);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(106, 25);
            this.bSubmit.TabIndex = 8;
            this.bSubmit.Text = "&Submit Code";
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // bWriteProt
            // 
            this.bWriteProt.Location = new System.Drawing.Point(38, 146);
            this.bWriteProt.Name = "bWriteProt";
            this.bWriteProt.Size = new System.Drawing.Size(106, 25);
            this.bWriteProt.TabIndex = 7;
            this.bWriteProt.Text = "Write &Protect";
            this.bWriteProt.Click += new System.EventHandler(this.bWriteProt_Click);
            // 
            // bErrCtr
            // 
            this.bErrCtr.Enabled = false;
            this.bErrCtr.Location = new System.Drawing.Point(38, 112);
            this.bErrCtr.Name = "bErrCtr";
            this.bErrCtr.Size = new System.Drawing.Size(106, 25);
            this.bErrCtr.TabIndex = 6;
            this.bErrCtr.Text = "Read ErrC&tr";
            this.bErrCtr.Click += new System.EventHandler(this.bErrCtr_Click);
            // 
            // tData
            // 
            this.tData.Location = new System.Drawing.Point(19, 78);
            this.tData.Name = "tData";
            this.tData.Size = new System.Drawing.Size(269, 22);
            this.tData.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data (String)";
            // 
            // tLen
            // 
            this.tLen.Location = new System.Drawing.Point(240, 26);
            this.tLen.MaxLength = 2;
            this.tLen.Name = "tLen";
            this.tLen.Size = new System.Drawing.Size(38, 22);
            this.tLen.TabIndex = 3;
            this.tLen.Leave += new System.EventHandler(this.tLen_Leave);
            this.tLen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tLen_KeyUp);
            this.tLen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tLen_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(182, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Length";
            // 
            // tAdd
            // 
            this.tAdd.Location = new System.Drawing.Point(77, 26);
            this.tAdd.MaxLength = 2;
            this.tAdd.Name = "tAdd";
            this.tAdd.Size = new System.Drawing.Size(38, 22);
            this.tAdd.TabIndex = 1;
            this.tAdd.TextChanged += new System.EventHandler(this.tAdd_TextChanged);
            this.tAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tAdd_KeyPress);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Address";
            // 
            // bReset
            // 
            this.bReset.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bReset.Location = new System.Drawing.Point(384, 345);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(90, 25);
            this.bReset.TabIndex = 7;
            this.bReset.Text = "R&eset";
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bQuit
            // 
            this.bQuit.Location = new System.Drawing.Point(557, 345);
            this.bQuit.Name = "bQuit";
            this.bQuit.Size = new System.Drawing.Size(90, 24);
            this.bQuit.TabIndex = 0;
            this.bQuit.Text = "&Quit";
            this.bQuit.Click += new System.EventHandler(this.bQuit_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.HorizontalScrollbar = true;
            this.lstOutput.ItemHeight = 12;
            this.lstOutput.Location = new System.Drawing.Point(346, 9);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.ScrollAlwaysVisible = true;
            this.lstOutput.Size = new System.Drawing.Size(345, 304);
            this.lstOutput.TabIndex = 8;
            // 
            // SLE4432_4442Main
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(708, 393);
            this.Controls.Add(this.lstOutput);
            this.Controls.Add(this.cbReader);
            this.Controls.Add(this.bQuit);
            this.Controls.Add(this.bReset);
            this.Controls.Add(this.fFunction);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.bInit);
            this.Controls.Add(this.fCardType);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SLE4432_4442Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alcor SLE4432/4442/5542 in PC/SC";
            this.Load += new System.EventHandler(this.SLE4432_4442Main_Load);
            this.fCardType.ResumeLayout(false);
            this.fFunction.ResumeLayout(false);
            this.fFunction.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SLE4432_4442Main());
		}

		private void SLE4432_4442Main_Load(object sender, System.EventArgs e)
		{
			// Established using ScardEstablishedContext()
			retcode = ModWinsCard.SCardEstablishContext(G_hContext, 0, 0, ref G_hContext);
			
			if (retcode !=  ModWinsCard.SCARD_S_SUCCESS) 
			{       
				lstOutput.Items.Add ("SCardEstablishContext Error"); 
			}

			InitMenu();
		}
		
		Char Chr(int i)
		{
			//Return the character of the given character value
			return Convert.ToChar(i);
		}
	
		Boolean InputOK(int checkType)
		{
			int indx;
  			
			switch (checkType)
			{
				case 0 :// for Read function
					if (tAdd.Text == "")
					{					  
						tAdd.Focus();
						return false;
					}
					if (tLen.Text == "")
					{
						tLen.Focus();
						return false;
					}
					break;
				case 1 :// for Write function
					if (tAdd.Text == "") 
					{
						tAdd.Focus();
						return false;
					}
					if(tLen.Text == "")
					{
						tLen.Focus();
						return false;
					}
					if(tData.Text == "") 
					{
						tData.Focus();
						return false;
					}
					break;
				case 2 :// for Verify function
					tAdd.Text = "";
					tLen.Text = "";
					if (tData.Text == "") 
					{
						tData.Focus();
						return false;
					}
					
					tData.Text = tData.Text.ToUpper();
					tmpStr = "";
						
					for(indx = 0; indx <= (tData.Text.Length) -1; indx++)
					{	
						if (tData.Text.Substring(indx, 1) != " ")
						{
							tmpStr = tmpStr + string.Format(tData.Text.Substring(indx, 1),"%02X");
						}
					}
					if (tmpStr.Length != 6) 
					{	
						tData.SelectAll();
						tData.Focus();
						return false;
					}
						
					for(indx = 0; indx <= (tmpStr.Length) -1; indx++)
					{	if (Convert.ToInt32(tmpStr[indx]) < 48 || Convert.ToInt32(tmpStr[indx]) > 57)
						{
							if (Convert.ToInt32(tmpStr[indx]) < 65 || Convert.ToInt32(tmpStr[indx]) > 70)
							{
								tData.SelectAll();
								tData.Focus();
								return false;
							}
						}
					}
					break;
			}
			return true;
		}
	

		private void ClearBuffers()
		{						
			long indx;
  
			for (indx=0; indx<262; indx++)
			{
				RecvBuff[indx] = 0x00;
				SendBuff[indx] = 0x00;
			}
												
		}

		int DisplayOut(int errType, int retVal, string PrintText, string AppText) 
		{
			//Displays the APDU sent and recieved 
			//returns 1 if erronous and 0 if successful
			int i;
	
			if (errType == 0)
			{
				i = lstOutput.Items.Add("> " + PrintText);
				lstOutput.SelectedIndex = i;
			}		//Information
			else if (errType == 1)
			{
				i = lstOutput.Items.Add(AppText + "Error> " + ModWinsCard.GetScardErrMsg(retVal));
				//Convert.ToUInt64 (retVal)).ToString()
					lstOutput.SelectedIndex = i;
				return 1;
				//Error
			}
			else if (errType == 2)
			{
				i = lstOutput.Items.Add(AppText + "< " + PrintText);
				lstOutput.SelectedIndex = i;
				//Into Card command
			}
			else if (errType ==3)
			{
				i = lstOutput.Items.Add(AppText + "> " + PrintText);
				lstOutput.SelectedIndex = i;
				//Out from Card command
			}
			
			return 0;
		}
		
		private void InitMenu()
		{
			cbReader.Items.Clear();
			bInit.Enabled = true;
			fCardType.Enabled = false;
			bConnect.Enabled = false;
			bReset.Enabled = false;
			fFunction.Enabled = false;
			lstOutput.Items.Clear();
			DisplayOut(0, 0, "Program Ready", "");
		}

		private void AddButtons()
		{
			cbReader.Enabled = true;
			bInit.Enabled = false;
			fCardType.Enabled = true;
			SLE4432.Checked = true;
			bConnect.Enabled = true;
			bReset.Enabled = true;
		}

		
		private void ClearFields()
		{
			tAdd.Text = "";
			tLen.Text = "";
			tData.Text = "";

		}

		private void bInit_Click(object sender, System.EventArgs e)
		{
			//Initialize List of Available Readers
			int pcchReaders = 0;
			int indx = 0;
			string rName = "";

			//Establish Context
			retcode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref G_hContext);
			
			if (retcode != ModWinsCard.SCARD_S_SUCCESS)
			{
				DisplayOut(1, retcode, "SCardEstablishContext Error: " + ModWinsCard.GetScardErrMsg(retcode), "MCU");
				return;
			}
			else
			{
				DisplayOut(0, retcode, "SCardEstablishContext Success", "MCU");
			}

			//Get readers buffer len
			retcode = ModWinsCard.SCardListReaders(G_hContext, null, null, ref pcchReaders);

			if (retcode != ModWinsCard.SCARD_S_SUCCESS)
			{
				DisplayOut(1, retcode, "SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retcode), "MCU");
				return;
			}

			//Set reader buffer size
			byte[] ReadersList = new byte[pcchReaders];

			// Fill reader list
			retcode = ModWinsCard.SCardListReaders(G_hContext, null, ReadersList, ref pcchReaders);
				
			if (retcode != ModWinsCard.SCARD_S_SUCCESS)
			{
				DisplayOut(1, retcode, "SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retcode), "MCU");
				return;
			}
			else
			{
				DisplayOut(0, retcode, "SCardListReaders Success", "MCU");
			}

			//Convert reader buffer to string
			while(ReadersList[indx] != 0)
			{
				
				while(ReadersList[indx] != 0)
				{
					rName = rName + (char)ReadersList[indx];		
					indx = indx + 1;
				}
				
				//Add reader name to list
				cbReader.Text = rName;
				cbReader.Items.Add(rName);
				rName = "";
				indx = indx + 1;
				
			}

			this.AddButtons();
			
		}

		private void bConnect_Click(object sender, System.EventArgs e)
		{
			
			if (this.ConnActive == true)
			{
				DisplayOut(0, 0, "Connection is already active", "MCU");
				return;
			}

			// 1. Connect to reader using SCARD_SHARE_DIRECT
			retcode = ModWinsCard.SCardConnect(G_hContext,
												cbReader.Text,
												ModWinsCard.SCARD_SHARE_DIRECT,
												0, 
												ref hCard,
												ref ActiveProtocol);

			if(retcode != ModWinsCard.SCARD_S_SUCCESS)
			{
                DisplayOut(1, retcode, "", "MCU");
			}

			// 2. Select Card Type 
			ClearBuffers();
			
            retcode = ModWinsCard.Alcor_SwitchCardMode(hCard, 0, 0x04); //0x04 SLE4442
			if (retcode != ModWinsCard.SCARD_S_SUCCESS) 
			{
                DisplayOut(1, retcode, "", "MCU");
				ConnActive = false;
				return;
			}

			// 3. Reconnect reader
			retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);		
			if(retcode != ModWinsCard.SCARD_S_SUCCESS)
			{	
				DisplayOut(1, retcode, "", "MCU");
				ConnActive = false;
				return;
			}

			retcode = ModWinsCard.SCardConnect(G_hContext, 
												cbReader.Text,
                                                ModWinsCard.SCARD_SHARE_EXCLUSIVE, 
												0 | 1, 
												ref hCard, 
												ref ActiveProtocol);
			if (retcode != ModWinsCard.SCARD_S_SUCCESS) 
			{       
				lstOutput.Items.Add ("Connection Error");
                DisplayOut(1, retcode, "", "MCU");
				ConnActive = false;
				return;
			}
			else
			{
				DisplayOut(0, 0, "Successful connection to " + cbReader.Text, "MCU");
				ConnActive = true;
				rreader = cbReader.Text;
			}	
			lstOutput.SelectedIndex = lstOutput.Items.Count -1;
  
			ConnActive = true;

			fFunction.Enabled = true;
			ClearFields(); 
			tAdd.Focus();
			
		}

		private void bReset_Click(object sender, System.EventArgs e)
		{
			//Disconnect  and unpower card
			retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
			
			if (retcode != ModWinsCard.SCARD_S_SUCCESS) 
			{       
				lstOutput.Items.Add ("Disconnection Error!"); 
			}
			else
			{
				lstOutput.Items.Add ("Disconnect OK");
				ConnActive = false;
			}
	
			lstOutput.SelectedIndex = lstOutput.Items.Count -1;
			ClearFields();
			InitMenu();
		}

		private void bQuit_Click(object sender, System.EventArgs e)
		{
			//terminate the application
			retcode = ModWinsCard.SCardReleaseContext(G_hContext);
			retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
			Application.Exit();
		}

		private void bErrCtr_Click(object sender, System.EventArgs e)
		{	
			int indx;
            byte bRecvLen = 0;

            DisplayOut(0, 0, "Read Security Memory", "");
			// 1. Clear all input fields
			ClearFields();

			// 2. Read input fields and pass data to card
			ClearBuffers();

            retcode = ModWinsCard.SLE4442Cmd_ReadSecurityMemory(hCard, 0, 0x04, ref RecvBuff[0], ref bRecvLen);
			if (retcode != ModWinsCard.SCARD_S_SUCCESS) 
			{
                DisplayOut(1, retcode, "", "MCU");
				return;
			}

            //3. Display data read from card 
            tmpStr = "";
            for (indx = 0; indx <= bRecvLen - 1; indx++)
			{
				tmpStr = tmpStr + string.Format("{0:x2}", RecvBuff[indx]).ToUpper() + " ";
			}
            DisplayOut(3, 0, tmpStr, "MCU");
		}

		private void bRead_Click(object sender, System.EventArgs e)
		{
			int indx;
            byte bRecvLen = 0;
            byte bAddress;
            byte bReadLen;
			
			// 1. Check for all input fields
			if(this.InputOK(0) == false)
			{
				return;
			}
            DisplayOut(0, 0, "Read Main Memory", "");

			// 2. Read input fields and pass data to card
			ClearBuffers();

 			bAddress = Convert.ToByte(tAdd.Text.Substring(0, 2),16);
 			bReadLen = Convert.ToByte(tLen.Text.Substring(0, 2),16);
            if (bReadLen > (0xFF - bAddress))
            {
                DisplayOut(3, 0, "Read Data Length isn't proper ( length <= 0xFF-Address )", "MCU");
                return;
            }

            retcode = ModWinsCard.SLE4442Cmd_ReadMainMemory(hCard, 0, bAddress, bReadLen, ref RecvBuff[0], ref bRecvLen);
			if(retcode != ModWinsCard.SCARD_S_SUCCESS)
			{
                DisplayOut(1, retcode, "", "MCU");
				return;
			}

			// 3. Display data read from card into Data textbox
			tmpStr = "";
			for(indx = 0; indx <= bReadLen -1; indx++)
			{
				tmpStr = tmpStr +  Convert.ToChar(RecvBuff[indx]);
			}
			tData.Text = tmpStr;

            tmpStr = "";
			for(indx = 0; indx <= bRecvLen -1; indx++)
			{
				tmpStr = tmpStr + string.Format("{0:x2}", RecvBuff[indx]).ToUpper() + " ";
			}
            DisplayOut(3, 0, tmpStr, "MCU");
		}

		private void bWriteProt_Click(object sender, System.EventArgs e)
		{
            int indx;
            byte bAddress;
            byte bWriteLen;
			
			// 1. Check for all input fields
			if(this.InputOK(1) == false)
			{
				return;
			}
            DisplayOut(0, 0, "Write Protection Memory", "");

			// 2. Read input fields and pass data to card
			tmpStr =tData.Text;
			ClearBuffers();

            bAddress = Convert.ToByte(tAdd.Text.Substring(0, 2), 16);
            if (bAddress > 0x1F)
            {
                DisplayOut(3, 0, "Wrotten Data Address isn't proper ( Address < 0x20 )", "MCU");
                return;
            }
            bWriteLen = Convert.ToByte(tLen.Text.Substring(0, 2), 16);
            if (bWriteLen > (0x20 - bAddress))
            {
                DisplayOut(3, 0, "Wrotten Data Length isn't proper ( length <= 0x20-Address )", "MCU");
                return;
            }

 			for(indx = 0; indx <= tmpStr.Length -1; indx++)
 			{
 				if (Convert.ToByte(Convert.ToByte(tmpStr[indx])) != 0x00 )
 				{	
 					SendBuff[indx] =  Convert.ToByte(tmpStr[indx]);  
 				}
 			}

            tmpStr = "Data(string) : " + tData.Text + " ==> Data(Hex) : ";
            for (indx = 0; indx <= bWriteLen - 1; indx++)
 			{
                retcode = ModWinsCard.SLE4442Cmd_WriteProtectionMemory(hCard, 0, (byte)(bAddress+indx), SendBuff[indx]);
 				tmpStr = tmpStr + string.Format("{0:x2}", SendBuff[indx]).ToUpper() + " ";
 			}
            DisplayOut(2, 0, tmpStr, "MCU");
            if (retcode != ModWinsCard.SCARD_S_SUCCESS)
            {
                return;
            }

			tData.Text = "";
		}

		private void bSubmit_Click(object sender, System.EventArgs e)
		{
			int indx;
			
			// 1. Check for all input fields
			if(this.InputOK(2) == false)
			{
				return;
			}
            DisplayOut(0, 0, "Verify PIN Number", "");

			// 2. Read input fields and pass data to card
			tmpStr = "";
			
			for(indx = 0; indx <= tData.Text.Length-1; indx++)
			{
				if (tData.Text.Substring(indx, 1) != " ")
				{
					tmpStr = tmpStr + tData.Text.Substring(indx, 1);
				}
			}
			
			ClearBuffers();
		
			for(indx = 0; indx <= 2; indx++)
			{
				SendBuff[indx] = Convert.ToByte(tmpStr.Substring(indx * 2, 2), 16);
				
			}

			tmpStr = "";			
			for(indx = 0; indx <= 2; indx++)
			{
				tmpStr = tmpStr + string.Format("{0:x2}", SendBuff[indx]).ToUpper() + " ";
			}

            DisplayOut(2, 0, tmpStr, "MCU");

            retcode = ModWinsCard.SLE4442Cmd_Verify(hCard, 0, 0x03, ref SendBuff[0]);		
			if(retcode != ModWinsCard.SCARD_S_SUCCESS)
			{
                DisplayOut(1, retcode, "", "MCU");
				return;
			}
            DisplayOut(0, 0, "Verify PIN Number Successfully!", "");

			tData.Text = "";
		}

		private void bWrite_Click(object sender, System.EventArgs e)
		{
            int indx;
            byte bAddress;
            byte bWriteLen;
			
			// 1. Check for all input fields
			if(this.InputOK(1) == false)
			{
				return;
			}
            DisplayOut(0, 0, "Write Main Memory", "");

			// 2. Read input fields and pass data to card
			tmpStr = tData.Text;
			ClearBuffers();

            bAddress = Convert.ToByte(tAdd.Text.Substring(0, 2), 16);
            bWriteLen = Convert.ToByte(tLen.Text.Substring(0, 2), 16);
            if (bWriteLen > (0xFF - bAddress))
            {
                DisplayOut(3, 0, "Wrotten Data Length isn't proper ( length <= 0xFF-Address )", "MCU");
                return;
            }

 			for(indx = 0; indx <= tmpStr.Length -1; indx++)
 			{
 				if (Convert.ToByte(Convert.ToByte(tmpStr[indx])) != 0x00 )
 				{	
 					SendBuff[indx] =  Convert.ToByte(tmpStr[indx]);  
 				}
 			}

            tmpStr = "Data(string) : " + tData.Text + " ==> Data(Hex) : ";
            for (indx = 0; indx <= bWriteLen - 1; indx++)
 			{
                retcode = ModWinsCard.SLE4442Cmd_UpdateMainMemory(hCard, 0, (byte)(bAddress+indx), SendBuff[indx]);
 				tmpStr = tmpStr + string.Format("{0:x2}", SendBuff[indx]).ToUpper() + " ";
 			}

            DisplayOut(2, 0, tmpStr, "MCU");
			
			if(retcode != ModWinsCard.SCARD_S_SUCCESS)
			{
				return;
			}

			tData.Text = "";
		}

		private void bChange_Click(object sender, System.EventArgs e)
		{	
			int indx;
			
			// 1. Check for all input fields
			if(this.InputOK(2) == false)
			{
				return;
			}
            DisplayOut(0, 0, "Change PIN Number", "");

			// 2. Read input fields and pass data to card
			tmpStr = "";
			
			for(indx = 0; indx <= tData.Text.Length-1; indx++)
			{
				if (tData.Text.Substring(indx, 1) != " ")
				{
					tmpStr = tmpStr + tData.Text.Substring(indx, 1);
				}
			}
			ClearBuffers();
						
			for(indx = 0; indx <= 2; indx++)
			{
				SendBuff[indx] = Convert.ToByte(tmpStr.Substring(indx * 2, 2), 16);
			}

			tmpStr = "";			
			for(indx = 0; indx <= 2; indx++)
			{
				tmpStr = tmpStr + string.Format("{0:x2}", SendBuff[indx]).ToUpper() + " ";
			}
            DisplayOut(2, 0, tmpStr, "MCU");

            for (indx = 0; indx <= 2; indx++)
            {
                retcode = ModWinsCard.SLE4442Cmd_UpdateSecurityMemory(hCard, 0, (byte)(indx+1), SendBuff[indx]);
            }
			
			if(retcode != ModWinsCard.SCARD_S_SUCCESS)
			{
				return;
			}

			tData.Text = "";
		}

		private void tAdd_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//Verify Input
			//Character 0-9 and A-F

			if (e.KeyChar < 97 || e.KeyChar  > 102)
				if (e.KeyChar < 48 || e.KeyChar  > 57)
					if (e.KeyChar < 65 || e.KeyChar > 70)
						if (e.KeyChar != (char)(Keys.Back))
							e.Handled = true;
		}

		private void tLen_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//Verify Input
			//Character 0-9 and A-F

			if (e.KeyChar < 97 || e.KeyChar  > 102)
				if (e.KeyChar < 48 || e.KeyChar  > 57)
					if (e.KeyChar < 65 || e.KeyChar > 70)
						if (e.KeyChar != (char)(Keys.Back))
							e.Handled = true;
		}

		private void tAdd_TextChanged(object sender, System.EventArgs e)
		{
			tAdd.Text = tAdd.Text.ToUpper();
			if (tAdd.Text.Length > 1)
			{
				tLen.Focus();
			}
		}

		private void tLen_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			tLen.Text = tLen.Text.ToUpper();
			if (tLen.Text.Length > 1)
			{
				tData.Focus();
			}
		}

		private void tLen_Leave(object sender, System.EventArgs e)
		{
			if(tLen.Text != "")
			{
				tData.Text = "";
				tData.MaxLength = Convert.ToByte(tLen.Text.Substring(0, 2),16);
			}
			else
			{
				tData.MaxLength = 0;
			}
		}

		private void SLE4432_Click(object sender, System.EventArgs e)
		{
			fFunction.Enabled = false;
			ClearFields();
			
			if (ConnActive == true) 
			{
				retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
				ConnActive = false;
			}
            
			retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
			ConnActive = false;
        
			bSubmit.Enabled = false;
			bChange.Enabled = false;
			bErrCtr.Enabled = false;
		}

		private void SLE4442_Click(object sender, System.EventArgs e)
		{
			fFunction.Enabled = false;
			ClearFields();
			
			if (ConnActive == true) 
			{
				retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
				ConnActive = false;
			}
            
			retcode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD);
			ConnActive = false;
        
			bSubmit.Enabled = true;
			bErrCtr.Enabled = true;
			bChange.Enabled = true;
		}
	}
}
