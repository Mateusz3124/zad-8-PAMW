   M S B A M L   `   `   `  ����W  SP04WeatherForecastAPI.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:P04WeatherForecastAPI.ClientP04WeatherForecastAPI.Client  5   	   ,    &P04WeatherForecastAPI.Client.LoginView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:P04WeatherForecastAPI.Client     5   	     � Title$  	LoginView��5   	   $	��185��6   $	��307��6(   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Email:��6   $��0��6!   $��0��6.   �� 5   
   -   5         ��Name$ EmailTextBox��5      $��0��6(   $��1��65   $��5q�6E   ��6P   �� *UserLoginDTO.Email+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��	Password:��6   $��1��6$   $��0��61   �� 5   
   -   5        $ PasswordBox��5      $��1��6'   $��1��64   $��5q�6D   ��6O   �� *UserLoginDTO.Password+$ TwoWay=�$ PropertyChanged=��� 5   
   $��Login��6   $��2��6B   $��2��6O   $��31,19,31,19q�6c   ��6!   �� *LoginCommand+6c   5      5      