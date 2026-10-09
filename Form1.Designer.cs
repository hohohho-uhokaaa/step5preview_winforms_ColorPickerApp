namespace wfai;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        swatchPanel = new FlowLayoutPanel();
        colorSwatch = new Panel();
        hLabel = new Label();
        hTrackBar = new TrackBar();
        sLabel = new Label();
        sTrackBar = new TrackBar();
        lLabel = new Label();
        lTrackBar = new TrackBar();
        colorCodeBox = new TextBox();
        pickButton = new Button();
        copyButton = new Button();
        SuspendLayout();
        //
        // swatchPanel
        //
        swatchPanel.AutoScroll = true;
        swatchPanel.FlowDirection = FlowDirection.TopDown;
        swatchPanel.Location = new Point(12, 12);
        swatchPanel.Name = "swatchPanel";
        swatchPanel.Size = new Size(120, 361);
        swatchPanel.TabIndex = 7;
        swatchPanel.WrapContents = false;
        //
        // colorSwatch
        //
        colorSwatch.BorderStyle = BorderStyle.FixedSingle;
        colorSwatch.Location = new Point(150, 12);
        colorSwatch.Name = "colorSwatch";
        colorSwatch.Size = new Size(300, 100);
        colorSwatch.TabIndex = 0;
        //
        // hLabel
        //
        hLabel.Location = new Point(150, 134);
        hLabel.Name = "hLabel";
        hLabel.Size = new Size(25, 20);
        hLabel.TabIndex = 1;
        hLabel.Text = "H";
        hLabel.TextAlign = ContentAlignment.MiddleRight;
        //
        // hTrackBar
        //
        hTrackBar.Location = new Point(182, 122);
        hTrackBar.Maximum = 360;
        hTrackBar.Name = "hTrackBar";
        hTrackBar.Size = new Size(268, 45);
        hTrackBar.TabIndex = 2;
        hTrackBar.TickFrequency = 30;
        hTrackBar.Scroll += HslTrackBar_Scroll;
        //
        // sLabel
        //
        sLabel.Location = new Point(150, 179);
        sLabel.Name = "sLabel";
        sLabel.Size = new Size(25, 20);
        sLabel.TabIndex = 3;
        sLabel.Text = "S";
        sLabel.TextAlign = ContentAlignment.MiddleRight;
        //
        // sTrackBar
        //
        sTrackBar.Location = new Point(182, 167);
        sTrackBar.Maximum = 100;
        sTrackBar.Name = "sTrackBar";
        sTrackBar.Size = new Size(268, 45);
        sTrackBar.TabIndex = 4;
        sTrackBar.TickFrequency = 10;
        sTrackBar.Scroll += HslTrackBar_Scroll;
        //
        // lLabel
        //
        lLabel.Location = new Point(150, 224);
        lLabel.Name = "lLabel";
        lLabel.Size = new Size(25, 20);
        lLabel.TabIndex = 5;
        lLabel.Text = "L";
        lLabel.TextAlign = ContentAlignment.MiddleRight;
        //
        // lTrackBar
        //
        lTrackBar.Location = new Point(182, 212);
        lTrackBar.Maximum = 100;
        lTrackBar.Name = "lTrackBar";
        lTrackBar.Size = new Size(268, 45);
        lTrackBar.TabIndex = 6;
        lTrackBar.TickFrequency = 10;
        lTrackBar.Scroll += HslTrackBar_Scroll;
        //
        // colorCodeBox
        //
        colorCodeBox.Font = new Font("Consolas", 16F);
        colorCodeBox.Location = new Point(150, 262);
        colorCodeBox.Name = "colorCodeBox";
        colorCodeBox.ReadOnly = true;
        colorCodeBox.Size = new Size(300, 32);
        colorCodeBox.TabIndex = 8;
        //
        // pickButton
        //
        pickButton.Location = new Point(150, 302);
        pickButton.Name = "pickButton";
        pickButton.Size = new Size(145, 40);
        pickButton.TabIndex = 9;
        pickButton.Text = "色を選ぶ";
        pickButton.UseVisualStyleBackColor = true;
        pickButton.Click += pickButton_Click;
        //
        // copyButton
        //
        copyButton.Location = new Point(305, 302);
        copyButton.Name = "copyButton";
        copyButton.Size = new Size(145, 40);
        copyButton.TabIndex = 10;
        copyButton.Text = "コピー";
        copyButton.UseVisualStyleBackColor = true;
        copyButton.Click += copyButton_Click;
        //
        // Form1
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(470, 385);
        Controls.Add(swatchPanel);
        Controls.Add(colorSwatch);
        Controls.Add(hLabel);
        Controls.Add(hTrackBar);
        Controls.Add(sLabel);
        Controls.Add(sTrackBar);
        Controls.Add(lLabel);
        Controls.Add(lTrackBar);
        Controls.Add(colorCodeBox);
        Controls.Add(pickButton);
        Controls.Add(copyButton);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "カラーパレット";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private FlowLayoutPanel swatchPanel;
    private Panel colorSwatch;
    private Label hLabel;
    private TrackBar hTrackBar;
    private Label sLabel;
    private TrackBar sTrackBar;
    private Label lLabel;
    private TrackBar lTrackBar;
    private TextBox colorCodeBox;
    private Button pickButton;
    private Button copyButton;
}
