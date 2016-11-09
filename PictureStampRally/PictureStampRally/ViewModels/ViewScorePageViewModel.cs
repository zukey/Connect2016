using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PictureStampRally.Models;


namespace PictureStampRally.ViewModels
{
    public class ViewScorePageViewModel : NotificationBase
    {
        IEnumerable<ThemeInfoViewItem> _themeList;
        public IEnumerable<ThemeInfoViewItem> ThemeList
        {
            get { return _themeList; }
            private set
            {
                SetProperty(ref _themeList, value);
            }
        }

        ThemeInfoViewItem _selectedTheme;
        public ThemeInfoViewItem SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                SetProperty(ref _selectedTheme, value);
            }
        }


        public async Task LoadThemeList()
        {
            using (var api = new PictureStampRallyWebApi())
            {
                var items = await api.ThemeInfo.GetAsync(1);
                ThemeList = items.Select(x => new ThemeInfoViewItem(x)).ToArray();
                if (ThemeList.Any())
                {
                    SelectedTheme = ThemeList.First();
                }
            }
        }

    }
}
