   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   H DBMP280-Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BMP280_ViewerBMP280_Viewer 5   	      BMP280_Viewer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   -localclr-namespace:BMP280_Viewer     5   	   -   5          � Title$  
MainWindow��5	   	   $	��350��6   $	��525��6)   .��5
      � .+�5   
   �� $��BMP280 Plotter��6   $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   � 5   
   $��0,35,0,0q�6    � 	Resources 5         CleanSeparator �� 
TargetType   LiveCharts.Wpf.Separator �� Property �� Value��%P   &	        �� 5      "  6/   .�5      ��  � {� .  6B   5      5       � ColumnDefinitions 5      �� 5      $	��35* �6#   �� 5      $	��12* �6#    � RowDefinitions 5      �� 5      $
��Auto �6    60   �� 5      $��* �6    6-   .+�5      #   LiveCharts.Wpf.CartesianChart  -   5          Name$ 
bm280Chart��5   !   $��1��65   $��2��6B   &    LiveCharts.Wpf.Charts.Base.Chart   AxisX 5         LiveCharts.Wpf.Axis  	   Title$
	 Time��6   6.   
   AxisY
 5           
Foreground
 � � �$	 Pressure [Pa]��62     5       
 �� ��$	 Temperature [DegC]��68      Position$ RightTop=�6S      	Separator 5!        5"      #��[  6,   6V   5$         Series 5'         LiveCharts.Wpf.LineSeries     LiveCharts.Wpf.Series   Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$   6%      	ScalesYAt$ 0��6/      Stroke
 � � �6=     5(      $   6%   $ 1��6/   
 �� ��6=   5*      5+      �� 5,   
   -   5         ��Name$ cbUARTDeviceList��5,      $��Right=�6-   $��	0,8,170,0q�6I   $	��Top=�6\   $��97��6t   �� 5-   
   -   5         ��Name$ 
btnRefresh��5-      $��Refresh��6%   $��	0,10,90,0q�67   $	��Top=�6J   $��Right=�6b   $��75��6~   6�   �� 5.   
   -   5        $ 
btnConnect��5.      $��Connect��6%   $��	0,10,10,0q�67   $	��Top=�6J   $��Right=�6b   $��75��6~   6�   5/      50      