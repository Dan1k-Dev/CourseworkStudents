   M S B A M L   `   `   `  ����   Study_Navigation!    Study_Navigation.MainWindow   DmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     [ WMahApps.Metro.IconPacks.Material, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  -     � Title$   ��$	��450��$	��380�� � 
ResizeMode$ NoResize=� � WindowStyle$ SingleBorderWindow=�
������  � WindowStartupLocation$ CenterScreen=�.��� .+��  � RowDefinitions �� $	��220 ��� $��* �.+���  �� CornerRadius$ 0��$��2��
��������� $��Center=�.+��� $��Авторизация��$��Light"�$��
gotham pro)�$��35(�
���   �$��Center=��� $��1��.+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ 
usernameTb��$��
gotham pro)�$��Light"�$��
Логин��$��20(�$��Center=�
���   �
������ $��0q�$	��235��$
��Left=� J� Opacity$	 0.9Q�$��25��$��63,0,0,0q�.  (MahApps.Metro.IconPacks.PackIconMaterial  -   $��AccountIcon��E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks.Material, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]]	   Kind$	 Account=�$��Center=�$��Center=�
���   �$	 0.9Q��� -   
 ��Name$
 UsernameBorder��$	��250��$��2��
���   �$	 0.8Q��� $ 
Horizontal=�$��0,20,0,0q�.+�G� -    G�Name$ 
passwordTb��$��	helvetica)�$��Light"�$��20(�
���   �
������  G� Password$ Пароль��$��0q�$	��235��$
��Left=�$��Center=�$	 0.9Q�$��25��$��63,0,0,0q�  -   $��PasswordIcon��$	 TextboxPassword=�$��Center=�$��Center=�
���   �$	 0.9Q��� -   $
 PasswordBorder��$	��250��$��2��
���   �$	 0.8Q��� $ 
Horizontal=�$��0,20,0,0q�.+��� -   $	��100��$��40��$��
ВОЙТИ��$��	60,0,50,0q�   ButtonStyle#��[  �� -	   $	��109��$��40��$��РЕГИСТРАЦИЯ��#��[  �� $ 
Horizontal=�$��
39,10,38,0q� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ 0.076Q�T� .+��� -
    ��Name$  ExceptionOfLoginOrPassword��$6��0Неверный логин или пароль!��$	��210��$��30��$��
gotham pro)�$��13(�$��Center=�$��Center=�$y�Hidden=�
���  ��