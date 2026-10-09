namespace wfai;

public partial class Form1 : Form
{
    private Color _currentColor = Color.Black;
    private bool _updating;

    public Form1()
    {
        InitializeComponent();
        ApplyColor(_currentColor);
        PopulateSwatches();
    }

    private void ApplyColor(Color color)
    {
        _currentColor = color;
        colorSwatch.BackColor = color;
        colorCodeBox.Text = $"#{color.R:X2}{color.G:X2}{color.B:X2}";

        // Sync the HSL trackbars to the applied color (guarded to avoid feedback loops).
        _updating = true;
        var (h, s, l) = RgbToHsl(color);
        hTrackBar.Value = Clamp((int)Math.Round(h), hTrackBar.Minimum, hTrackBar.Maximum);
        sTrackBar.Value = Clamp((int)Math.Round(s), sTrackBar.Minimum, sTrackBar.Maximum);
        lTrackBar.Value = Clamp((int)Math.Round(l), lTrackBar.Minimum, lTrackBar.Maximum);
        _updating = false;
    }

    private void pickButton_Click(object? sender, EventArgs e)
    {
        using var dialog = new ColorDialog
        {
            AllowFullOpen = true,
            FullOpen = true,
            Color = _currentColor,
        };

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            ApplyColor(dialog.Color);
        }
    }

    private void copyButton_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(colorCodeBox.Text))
        {
            Clipboard.SetText(colorCodeBox.Text);
        }
    }

    private static readonly Color[] SwatchColors =
    {
        Color.FromArgb(244, 67, 54),   // Red
        Color.FromArgb(233, 30, 99),   // Pink
        Color.FromArgb(156, 39, 176),  // Purple
        Color.FromArgb(103, 58, 183),  // Deep Purple
        Color.FromArgb(63, 81, 181),   // Indigo
        Color.FromArgb(33, 150, 243),  // Blue
        Color.FromArgb(3, 169, 244),   // Light Blue
        Color.FromArgb(0, 188, 212),   // Cyan
        Color.FromArgb(0, 150, 136),   // Teal
        Color.FromArgb(76, 175, 80),   // Green
        Color.FromArgb(139, 195, 74),  // Light Green
        Color.FromArgb(205, 220, 57),  // Lime
        Color.FromArgb(255, 235, 59),  // Yellow
        Color.FromArgb(255, 152, 0),   // Orange
        Color.FromArgb(255, 87, 34),   // Deep Orange
        Color.FromArgb(121, 85, 72),   // Brown
        Color.FromArgb(96, 125, 139),  // Blue Grey
        Color.FromArgb(0, 0, 0),       // Black
        Color.FromArgb(255, 255, 255), // White
    };

    private void PopulateSwatches()
    {
        foreach (var color in SwatchColors)
        {
            var swatch = new Panel
            {
                BackColor = color,
                Size = new Size(96, 40),
                Margin = new Padding(4),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = color,
            };
            swatch.Click += Swatch_Click;
            swatchPanel.Controls.Add(swatch);
        }
    }

    private void Swatch_Click(object? sender, EventArgs e)
    {
        if (sender is Panel { Tag: Color color })
        {
            ApplyColor(color);
        }
    }

    private void HslTrackBar_Scroll(object? sender, EventArgs e)
    {
        if (_updating)
        {
            return;
        }

        var color = HslToRgb(hTrackBar.Value, sTrackBar.Value, lTrackBar.Value);
        _currentColor = color;
        colorSwatch.BackColor = color;
        colorCodeBox.Text = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
    }

    private static int Clamp(int value, int min, int max)
        => value < min ? min : value > max ? max : value;

    private static (double h, double s, double l) RgbToHsl(Color color)
    {
        double r = color.R / 255.0;
        double g = color.G / 255.0;
        double b = color.B / 255.0;
        double max = Math.Max(r, Math.Max(g, b));
        double min = Math.Min(r, Math.Min(g, b));
        double h, s, l = (max + min) / 2.0;

        if (max == min)
        {
            h = s = 0;
        }
        else
        {
            double d = max - min;
            s = l > 0.5 ? d / (2.0 - max - min) : d / (max + min);
            if (max == r)
                h = (g - b) / d + (g < b ? 6 : 0);
            else if (max == g)
                h = (b - r) / d + 2;
            else
                h = (r - g) / d + 4;
            h /= 6.0;
        }

        return (h * 360.0, s * 100.0, l * 100.0);
    }

    private static Color HslToRgb(double h, double s, double l)
    {
        h /= 360.0;
        s /= 100.0;
        l /= 100.0;

        double r, g, b;
        if (s == 0)
        {
            r = g = b = l;
        }
        else
        {
            double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            double p = 2 * l - q;
            r = HueToRgb(p, q, h + 1.0 / 3.0);
            g = HueToRgb(p, q, h);
            b = HueToRgb(p, q, h - 1.0 / 3.0);
        }

        return Color.FromArgb(
            Clamp((int)Math.Round(r * 255), 0, 255),
            Clamp((int)Math.Round(g * 255), 0, 255),
            Clamp((int)Math.Round(b * 255), 0, 255));
    }

    private static double HueToRgb(double p, double q, double t)
    {
        if (t < 0) t += 1;
        if (t > 1) t -= 1;
        if (t < 1.0 / 6.0) return p + (q - p) * 6 * t;
        if (t < 1.0 / 2.0) return q;
        if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6;
        return p;
    }
}
