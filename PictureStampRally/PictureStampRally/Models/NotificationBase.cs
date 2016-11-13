using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PictureStampRally.Models
{
    /// <summary>
    /// 変更通知基底クラス
    /// </summary>
    public class NotificationBase : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティ変更イベントハンドラ
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティに値を設定します。
        /// </summary>
        /// <typeparam name="T">プロパティの型</typeparam>
        /// <param name="field">セットするフィールド参照</param>
        /// <param name="value">セットする値</param>
        /// <param name="property">プロパティ名</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] String property = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            RaisePropertyChanged(property);
            return true;
        }

        /// <summary>
        /// プロパティに値を設定します。
        /// </summary>
        /// <typeparam name="T">プロパティの型</typeparam>
        /// <param name="currentValue">現在値</param>
        /// <param name="newValue">新しい値</param>
        /// <param name="DoSet">セット時アクション</param>
        /// <param name="property">プロパティ名</param>
        /// <returns></returns>
        protected bool SetProperty<T>(T currentValue, T newValue, Action DoSet, [CallerMemberName] String property = null)
        {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue)) return false;
            DoSet.Invoke();
            RaisePropertyChanged(property);
            return true;
        }

        /// <summary>
        /// PropertyChangedイベントを発火します。
        /// </summary>
        /// <param name="property"></param>
        protected void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }

    /// <summary>
    /// 変更通知基底クラス(Generic)
    /// </summary>
    /// <typeparam name="T">型</typeparam>
    public class NotificationBase<T> : NotificationBase where T : class, new()
    {
        protected T This;

        public static implicit operator T(NotificationBase<T> thing) { return thing.This; }

        public NotificationBase(T thing = null)
        {
            This = (thing == null) ? new T() : thing;
        }
    }
}
