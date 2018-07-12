using System;
using System.Collections.Generic;

using System.Text;
using System.Drawing;

namespace CRD.WinUI.Forms
{
    //窗体接口
    public interface IMainForm
    {
        void PerformChangeSkinColor();
        void PerformChangeSkinColor(SkinColor skinColor);
        void PerformChangeBackgroundStripe(BackgroundStripe backgroundStripe);
        void PerformAllFormChangeSkinColor(SkinColor skinColor);

        SkinColor CurrentSkinColor {get;set;}

        Color MainFormBackGroundColor { get; }
        Color MainFormBackGroundColor2 { get; }
        Color ControlBackColor { get; }
        Color ControlBorderBackColor { get; }
        Color PicboxBorderBackColorYellow { get; }
    }
}
