   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  H DBMP280-Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BMP280_ViewerBMP280_Viewer    BMP280_Viewer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     -localclr-namespace:BMP280_Viewer     -     � Title$  
MainWindow��$	��350��$	��525��.��� .+��� $��BMP280 Plotter��$
��Left=�$��	10,10,0,0q�$	��Top=�� $��0,35,0,0q� � 	Resources    CleanSeparator �� 
TargetType   LiveCharts.Wpf.Separator �� Property �� Value��%+   &	        �� "  .���  � {� .   � ColumnDefinitions �� $	��35* ��� $	��12* � � RowDefinitions �� $
��Auto ��� $��* �.+�#   LiveCharts.Wpf.CartesianChart  -     Name$ 
bm280Chart��$��1��$��2��&    LiveCharts.Wpf.Charts.Base.Chart   AxisX    LiveCharts.Wpf.Axis  	   Title$
	 Time��
   AxisY
      
Foreground
 � � �$	 Pressure [Pa]��  
 �� ��$	 Temperature [DegC]��   Position$ RightTop=�   	Separator   #��[     Series    LiveCharts.Wpf.LineSeries     LiveCharts.Wpf.Series   Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$      	ScalesYAt$ 0��   Stroke
 � � �  $   $ 1��
 �� ���� -    ��Name$ cbUARTDeviceList��$��Right=�$��	0,8,170,0q�$	��Top=�$��97���� -    ��Name$ 
btnRefresh��$��Refresh��$��	0,10,90,0q�$	��Top=�$��Right=�$��75���� -   $ 
btnConnect��$��Connect��$��	0,10,10,0q�$	��Top=�$��Right=�$��75��