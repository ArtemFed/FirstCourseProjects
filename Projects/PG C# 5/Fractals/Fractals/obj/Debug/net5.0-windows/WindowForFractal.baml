   M S B A M L   `   `   `  ????  Fractals    Fractals.WindowFractal   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          ?Name$  fractalWindow??5   	    ? Title$ Window1??5   	   $	??450??5	   	   $	??800??5
   	    ? 
ResizeMode$ 	CanResize=?5   	   .??5      ? .+?5   
   ?? -   5         ??Name$ scroll??5      $??Visible=?5      $??Visible=?5       K? ZIndex$ 1??5      .??5      ?? -   5         ??Name$ 
MainCanvas??5      $??Stretch=?5      5      ?? 5   
   $??Bottom=?5      $
??Left=?5       $??45??5!      $??63??5"      $??0,0,0,19q?5#      $ 2??5$      .+?5&      ?? $??Zoom:      x??6   $??79??6+   $??16??66   $??5,0,5,0q?6B   $
??Left=?6T   ?? 5(      -   5         ??Name$ LabelValueZoom??5(      $	??1.0??6,   $??17??6:   $??16??6E   $??0q?6Q   $??Center=?6]    ?? Left$ 40                    ??6?   ?? 5+      -   5        $??25??5,      $??70??5-      $??
ScreenShot??5.      $??13(?50      
 ?? Top$ 20??6   51      ?? 53   
   $
??Left=?54      $	??107??55      $??46??56      $	??Top=?57      $ 2??58      .+?59      ?? $??26??5:      $??54??5;      $??Глубина??5<      $ -6??5=      ?? 5>      -   5        $ LabelForSliderDepthValue??5?      $ 66??5@      $ -6??5A      $??26??5B      $??41??5C      $??5??5D      ?? 5F      -   5        	 ??Name$	 SliderForDepth??5G      $	??107??5H      $ 18??5I      
 ? SmallChange$
 1Q?5K       ?? IsSnapToTickEnabled$
 True??5L       ?? TickFrequency$ 1Q?5M       ? LargeChange$ 1Q?5N       ? Value$ 5Q?5O       ?? TickPlacement$ TopLeft=?5P      5Q      5S      5T      