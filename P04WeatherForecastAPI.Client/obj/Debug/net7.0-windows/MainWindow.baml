   M S B A M L   `   `   `  ����W  SP04WeatherForecastAPI.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:P04WeatherForecastAPI.ClientP04WeatherForecastAPI.Client  5   	   a5clr-namespace:P04WeatherForecastAPI.Client.Converters'P04WeatherForecastAPI.Client.Converters  5   	   -    'P04WeatherForecastAPI.Client.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:P04WeatherForecastAPI.Client     5   	   L
converters5clr-namespace:P04WeatherForecastAPI.Client.Converters     5   	     � Title$  
MainWindow��5	   	   $	��420��6   $	��400��6)    � 	Resources 5
         boolToVisConvK  EP04WeatherForecastAPI.Client.Converters.TemperatureToDisplayConverter  tmpToDispConv  mainButtonStyle �� 
TargetType �� Property �� Value  mainLabelStyle��%�  &	        &	      &	 &     &	     �� 5   
   6@     5   
   6K   �� 5   
   " ��6(   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 10q�6(   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 ��ح�6+   �� 5       � ��
 ��  �6+   5      �� 5   
   " ��6'   .�5      ��  � ��$ 14(�6)   �� 5       � ��$ Center=�64   �� 5       � ��
 �  ��6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��204.04 �6   �� 5      $��44 �6   �� 5      $��172.42 �6   �� 5       $��* �6    � ColumnDefinitions 5"   
   �� 5#      $
��Auto �6   �� 5$      $��* �6   .+�5'   
   ]� $��0��6   $��0��6$   $��10,10,10,10q�61   $��3��6F   .+�5(      �� $	��Top=�6   $��
Open Boook��6*   #��[ 6i   ��6?   �� *OpenBookWindowCommand+6�   �� 5)      $	��Top=�6   $��Login��6*   #��[ 6e   ��6:   �� *OpenLoginWindowCommand+6�   �� 5*      $	��Top=�6   $��City:��6)   #��[ 69   6c   �� 5+      -   5         ��Name$ txtCity��5+   +   $	��Top=�6   6>   �� 5,      -   5         ��Name$ 	btnSearch��5,   *   $	��Top=�6   $��Search��6=   #��[ 6�   ��6N   �� *LoadCitiesCommand+��6t   �� *Text+	 �� ElementName$	 txtCity��6�   �� 5-      -   5        
 ��Name$
 lbData��5-   %   $	��200��6    �� DisplayMemberPath$ LocalizedName��6z   $��0,10,0,0q�6�   ��65   �� *Cities+ �� SelectedItem 6T   �� *SelectedCity+6�   5.      �� 50   
   $��1��6   $��0��6%   $��10,10,10,10q�62   $��3��6G   .+�51      �� $��Center=�6   $��Temperature for city:��61   #��[ 6Q   6{   �� 52      -   5         ��Name$ lblCityName��52      #��[ 6X   ��6)   �� *SelectedCity.LocalizedName+6�   �� 53      $	��is:��6   #��[ 6"   6L   �� 54      -   5        $ lblTemperatureValue��54      #��[ 6�   ��61   �� * WeatherView.CurrentTemperature+ �� 	Converter# [ 6�   �� 55      $	��100��6r   $��/Images/rain.jpg��6   y�6   �� *WeatherView.HasPrecipitation+# [  6   56      57      58      