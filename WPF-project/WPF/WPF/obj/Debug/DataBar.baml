   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5          WPF.DataBar   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      localclr-namespace:WPF  5      -   5          >�Name$  _this��5      
���  ��$��33��5	   D    � 	Resources 5         WPF.RightMarginConverter   RightMarginConverter   WPF.LeftMarginConverter  LeftMarginConverter   WPF.ValueConverter  ValueConverter!   WPF.LableAlignmentConverter  LableAlignmentConverter��%�   &	        &	      &	 .     &	 E       5   
   5        5   
   5        5   
   5        5   
   5      5      .��5      � $��Stretch=�6o   $��Stretch=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   ��6   ��  �� ElementName$ _this�� �� Path$ Width���6<   �� $ _this��$ Height�.+�5   
   �� -   5         ��Name$ Right��5      
���   �$ 0.5,0.5&�6`   ��6#   �� *	PlusBrush+$ _this����5      `� 5       `� 	Converter# [  6   .1�5      �� $ Value�6   1  +System.Diagnostics.PresentationTraceSources   
TraceLevel$
 High=�6o    �� RelativeSource 6+   �� 	 �� AncestorType"	 >�6o   �� 5      $ Range�6   $
 High=�6p    6+   �� "	 >�6p   �� 5      $ _this��6   $ Width�62   5      5      �� 5   
   -   5        $
 Left��5      
���   �$ 0.5,0.5&�6`   ��6"   �� *
MinusBrush+$ _this����5       `� 5!      # [ 6   .1�5"      �� $ Value�6   $
 High=�6o    6+   �� "	 >�6o   �� 5#      $ Range�6   $
 High=�6p    6+   �� "	 >�6p   �� 5$      $ _this��6   $ Width�62   5%      5'      �� 5(   
   -   5        
 ��Name$
 lable��5(      $��Arial)�6L   $��Center=�6_   ��6   �� *Height+$ _this����5)      `� 5*      # [ 6   .1�5+      �� $ Value�6   $
 High=�6o    6+   �� "	 >�6o   5,      .��5/      `� # [ 6   .1�50      �� $ Value�6   $
 High=�6k    6'   �� "	 >�6k   51      52      53      54      