﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "905AEC88E1CD853BF028943489384804DF268EAB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace simple_puzzle_game {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image red1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image grid2;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image grid3;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image grid4;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image grid5;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image grid6;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image grid7;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image grid8;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image red2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/simple_puzzle_game;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.red1 = ((System.Windows.Controls.Image)(target));
            
            #line 23 "..\..\..\MainWindow.xaml"
            this.red1.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseDown);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\MainWindow.xaml"
            this.red1.MouseMove += new System.Windows.Input.MouseEventHandler(this.Tile_MouseMove);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\MainWindow.xaml"
            this.red1.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.grid2 = ((System.Windows.Controls.Image)(target));
            
            #line 25 "..\..\..\MainWindow.xaml"
            this.grid2.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseDown);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\MainWindow.xaml"
            this.grid2.MouseMove += new System.Windows.Input.MouseEventHandler(this.Tile_MouseMove);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\MainWindow.xaml"
            this.grid2.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.grid3 = ((System.Windows.Controls.Image)(target));
            
            #line 27 "..\..\..\MainWindow.xaml"
            this.grid3.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseDown);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\MainWindow.xaml"
            this.grid3.MouseMove += new System.Windows.Input.MouseEventHandler(this.Tile_MouseMove);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\MainWindow.xaml"
            this.grid3.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.grid4 = ((System.Windows.Controls.Image)(target));
            
            #line 30 "..\..\..\MainWindow.xaml"
            this.grid4.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseDown);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\MainWindow.xaml"
            this.grid4.MouseMove += new System.Windows.Input.MouseEventHandler(this.Tile_MouseMove);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\MainWindow.xaml"
            this.grid4.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.grid5 = ((System.Windows.Controls.Image)(target));
            
            #line 32 "..\..\..\MainWindow.xaml"
            this.grid5.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseDown);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\MainWindow.xaml"
            this.grid5.MouseMove += new System.Windows.Input.MouseEventHandler(this.Tile_MouseMove);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\MainWindow.xaml"
            this.grid5.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.grid6 = ((System.Windows.Controls.Image)(target));
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.grid6.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseDown);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.grid6.MouseMove += new System.Windows.Input.MouseEventHandler(this.Tile_MouseMove);
            
            #line default
            #line hidden
            
            #line 34 "..\..\..\MainWindow.xaml"
            this.grid6.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.grid7 = ((System.Windows.Controls.Image)(target));
            
            #line 37 "..\..\..\MainWindow.xaml"
            this.grid7.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseDown);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\MainWindow.xaml"
            this.grid7.MouseMove += new System.Windows.Input.MouseEventHandler(this.Tile_MouseMove);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\MainWindow.xaml"
            this.grid7.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.grid8 = ((System.Windows.Controls.Image)(target));
            
            #line 39 "..\..\..\MainWindow.xaml"
            this.grid8.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseDown);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\MainWindow.xaml"
            this.grid8.MouseMove += new System.Windows.Input.MouseEventHandler(this.Tile_MouseMove);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\MainWindow.xaml"
            this.grid8.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.red2 = ((System.Windows.Controls.Image)(target));
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.red2.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseDown);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.red2.MouseMove += new System.Windows.Input.MouseEventHandler(this.Tile_MouseMove);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.red2.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Tile_MouseUp);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 45 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewGameButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

