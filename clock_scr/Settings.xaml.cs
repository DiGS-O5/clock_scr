using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FontFamily = System.Windows.Media.FontFamily;

namespace clock_scr
{
    /// <summary>
    /// Settings.xaml の相互作用ロジック
    /// </summary>
    public partial class Settings : Window
    {

        public Settings()
        {
            InitializeComponent();
            MainContentFrame.Content = new MainPage();
            cmbSelectFont.ItemsSource = GetFontList();

            sliderOffsetHM.Value = Properties.Settings.Default.offsetHM;
            sliderWatchSize.Value = Properties.Settings.Default.cameraDistance;
            sliderGradientBorder.Value = Properties.Settings.Default.gradientBorder;
            sliderWatchFontSize.Value = Properties.Settings.Default.watchFontSize;
            cmbTimeFormat.SelectedIndex = Properties.Settings.Default.timeFormat;
            sliderOffsetTF.Value = Properties.Settings.Default.offsetTF;
            cmbDateIndication.SelectedIndex = Properties.Settings.Default.dateIndication;
            selectDisplayColor.Color = Properties.Settings.Default.displayColor;
            selectBackFrameColor.Color = Properties.Settings.Default.backFrameColor;
            selectWindow.Value = Properties.Settings.Default.checkBit;
            exitSetting.Value = Properties.Settings.Default.exitBit;

            WpfColorPicker.ConfirmColor += ColorChanged;

            var selectFont = cmbSelectFont.Items.Cast<MyFont>().FirstOrDefault(f => f.LocalFontName.Contains(Properties.Settings.Default.selectFont) || f.FontFamily.Source.Contains(Properties.Settings.Default.selectFont));
            if (selectFont != null)
            {
                cmbSelectFont.SelectedItem = selectFont;
            }
        }

        public class MyFont
        {
            public FontFamily FontFamily { get; set; } = default!;
            public string LocalFontName { get; set; } = string.Empty;

            public override string ToString()
            {
                return LocalFontName;
            }
        }

        private MyFont[] GetFontList()
        {
            this.Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);
            var fonts = Fonts.SystemFontFamilies.Select(i => new MyFont() { FontFamily = i, LocalFontName = i.Source }).ToArray();
            fonts.Select(i => i.LocalFontName = i.FontFamily.FamilyNames
                .FirstOrDefault(j => j.Key == this.Language).Value ?? i.FontFamily.Source).ToArray();

            return fonts;
        }

        void Sendsettings()
        {
            var mainPage = MainContentFrame.Content as MainPage;
            if (mainPage != null)
            {
                Debug.WriteLine(cmbSelectFont.Text);
                mainPage.SetSettings(sliderOffsetHM.Value, sliderWatchSize.Value, sliderGradientBorder.Value, sliderWatchFontSize.Value, cmbTimeFormat.SelectedIndex, sliderOffsetTF.Value, cmbDateIndication.SelectedIndex, selectDisplayColor.Color, selectBackFrameColor.Color, cmbSelectFont.Text);
                mainPage.InitializeWatch();
            }
        }

        void SliderChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Sendsettings();
        }

        private void ComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            Sendsettings();
        }

        private void ColorChanged(object? sender, EventArgs e)
        {
            Sendsettings();
        }

        void Save_Click(object sender, RoutedEventArgs e)
        {
            var mainPage = MainContentFrame.Content as MainPage;
            if (mainPage != null)
            {
                Properties.Settings.Default.rotateAngel = mainPage.GetMatrix();
            }
            Properties.Settings.Default.offsetHM = sliderOffsetHM.Value;
            Properties.Settings.Default.cameraDistance = sliderWatchSize.Value;
            Properties.Settings.Default.gradientBorder = sliderGradientBorder.Value;
            Properties.Settings.Default.watchFontSize = sliderWatchFontSize.Value;
            Properties.Settings.Default.timeFormat = cmbTimeFormat.SelectedIndex;
            Properties.Settings.Default.offsetTF = sliderOffsetTF.Value;
            Properties.Settings.Default.dateIndication = cmbDateIndication.SelectedIndex;
            Properties.Settings.Default.displayColor = selectDisplayColor.Color;
            Properties.Settings.Default.backFrameColor = selectBackFrameColor.Color;
            Properties.Settings.Default.checkBit = selectWindow.Value;
            Properties.Settings.Default.exitBit = exitSetting.Value;
            Properties.Settings.Default.Save();
        }

        void Reset_Click(object sender, RoutedEventArgs e)
        {
            sliderOffsetHM.Value = Convert.ToDouble(Properties.Settings.Default.Properties["OffsetHM"].DefaultValue);
            sliderWatchSize.Value = Convert.ToDouble(Properties.Settings.Default.Properties["cameraDistance"].DefaultValue);
            sliderGradientBorder.Value = Convert.ToDouble(Properties.Settings.Default.Properties["gradientBorder"].DefaultValue);
            sliderWatchFontSize.Value = Properties.Settings.Default.watchFontSize;
            cmbTimeFormat.SelectedIndex = Convert.ToInt16(Properties.Settings.Default.Properties["timeFormat"].DefaultValue);
            sliderOffsetTF.Value = Convert.ToDouble(Properties.Settings.Default.Properties["offsetTF"].DefaultValue);
            cmbDateIndication.SelectedIndex = Convert.ToInt16(Properties.Settings.Default.Properties["dateIndication"].DefaultValue);
            selectDisplayColor.Color = (string)Properties.Settings.Default.Properties["displayColor"].DefaultValue;
            selectBackFrameColor.Color = (string)Properties.Settings.Default.Properties["backFrameColor"].DefaultValue;
            selectWindow.Value = Convert.ToInt16(Properties.Settings.Default.Properties["checkBit"].DefaultValue);
            exitSetting.Value = Convert.ToInt16(Properties.Settings.Default.Properties["exitBit"].DefaultValue);
            var mainPage = MainContentFrame.Content as MainPage;
            if (mainPage != null)
            {
                mainPage.SetMatrix((string)Properties.Settings.Default.Properties["rotateAngel"].DefaultValue);
            }
        }
    }
}
