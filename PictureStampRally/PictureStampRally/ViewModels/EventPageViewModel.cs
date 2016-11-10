using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PictureStampRally.Models;

namespace PictureStampRally.ViewModels
{
    public class EventPageViewModel : NotificationBase
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

        EventInfo _eventInfo;
        public EventInfo EventInfo
        {
            get { return _eventInfo; }
            private set
            {
                SetProperty(ref _eventInfo, value);
            }
        }


        public async Task LoadThemeList(int eventId)
        {
            using (var api = new PictureStampRallyWebApi())
            {
                // イベント情報を取得
                var events = await api.Events.GetAsync();
                EventInfo = events.FirstOrDefault(x => x.Id == eventId);

                // お題リストを取得
                var items = await api.ThemeInfo.GetAsync(eventId);
                ThemeList = items.Select(x => new ThemeInfoViewItem(x)).ToArray();
                if (ThemeList.Any())
                {
                    SelectedTheme = ThemeList.First();
                }
            }
        }


    }
}
