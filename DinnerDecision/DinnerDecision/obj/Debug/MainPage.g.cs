﻿

#pragma checksum "C:\Users\bunny_000\Documents\Visual Studio 2012\Projects\DinnerDecision\DinnerDecision\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B4BA99DDD55DDD807FB3B4A6C4B1FA61"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DinnerDecision
{
    partial class MainPage : global::DinnerDecision.Common.LayoutAwarePage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 54 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.StartButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 55 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.MenuButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 41 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


