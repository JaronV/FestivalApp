   M S B A M L   `   `   `  ����F  BFestivalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FestivalApp.ViewModelFestivalApp.ViewModel  5      k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.24.16411, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7pQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45GalaSoft.MvvmLight.Command 5      %    FestivalApp.View.Contactpersoon   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2vm#clr-namespace:FestivalApp.ViewModel     5      acmdQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45     5        � 	Resources  5
         ContactPersonTemplate  TextboxError �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value  ComboBoxError  ErrorTemplate��%=  &	        &	 Y     &	 �     &	 e    �� 5   
   .R�5      �� .+�5      �� ��6   �� *Name+5      5      �� 5   
   " ��6%    5      P� 5       �@=�HasError . . �5      ��  � ��
 �  ��63   5      5      �� 5   
   " ��6&    5      P� 5       �@=�HasError . . �5      ��  � ��
 �  ��63   5      5      �� 5!   
   .R�5"      �� .+�5#      �� 
���  ����6-   �� *[0].ErrorContent+�� 5$      
���  ��$��2q�6+   ._�5%      �� 5&      5(      5)      5+      .��5-      �  � DataContext 5.   
   ,  &FestivalApp.ViewModel.ContactpersoonVM  5/      .+�51   
   �� $��Contactpersonen��6   $
��Left=�6*   $��	10,27,0,0q�6E   $	��Top=�6X   $��24(�6p   �� 52   
   #��[  69   $
��Left=�6�   $	��286��6�   $��
30,168,0,0q�6�   $	��Top=�6�   $��191.037��6�   ��6   �� *ContactPersons+ �� SelectedItem 6o   �� *SelectedContactPersoon+6�   �� 53   
   $
��Name��6   $
��Left=�6   $��256.833,109.923,0,0q�6:   $	��Top=�6W   $��16(�6o   �� 54   
   $��Jobrole��6   $
��Left=�6"   $��257,160,0,0q�6=   $	��Top=�6R   $��16(�6j   �� 55   
   	 �� DisplayMemberPath$
	 Name��56      
 �� SelectedValuePath$
 ID��5:       =� ErrorTemplate# [ 5;      #��[ 5<      $
��Left=�5=      $��368,161,0,0q�6(   $	��Top=�6=   $	��120��6U   ��57      �� *
Jobroles+ 58      �� * SelectedContactPersoon.JobRole+ �� ValidatesOnDataErrors .  �� SelectedValue 59      �� *#!SelectedContactPersoon.JobRole.ID+5=   U   �� 5?   
   $	��New��6=   $
��Left=�6K   $��257,437,0,0q�6f   $	��Top=�6{   $��93��6�   $��38��6�   ��6   �� *AddContactPersonCommand+6�   �� 5@   
   $��Opslaan��6>   $
��Left=�6P   $��363,437,0,0q�6k   $	��Top=�6�   $��93��6�   $��38��6�   ��6   �� *SaveContactPersonCommand+6�   �� 5A   
   $��Verwijderen��6@   $
��Left=�6V   $��466,437,0,0q�6q   $	��Top=�6�   $��93��6�   $��38��6�   ��6   �� *DeleteContactPersonCommand+6�   �� 5B   
   $��Company��6   $
��Left=�6"   $��257,207,0,0q�6=   $	��Top=�6R   $��28��6j   $��70��6v   $��16(�6�   �� 5C   
   $��City
��6   $
��Left=�6)   $��257,253,0,0q�6D   $	��Top=�6Y   $��28��6q   $��70��6}   $��16(�6�   �� 5D   
   $��Email��6   $
��Left=�6    $��257,286,0,0q�6;   $	��Top=�6P   $��28��6h   $��70��6t   $��16(�6   �� 5E   
   $��
Telefoon
��6   $
��Left=�6-   $��257,319,0,0q�6H   $	��Top=�6]   $��28��6u   $��70��6�   $��16(�6�   �� 5F   
   $	��GSM��6   $
��Left=�6   $��257,352,0,0q�69   $	��Top=�6N   $��28��6f   $��70��6r   $��16(�6}   �� 5G   
   -   5         ��Name$ 	txtSearch��5G      $
��Left=�6%   $��23��6@   $��
30,118,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $��zoeken��6t   $	��Top=�6�   $	��108��6�   �� 5I   
   $
��Left=�6   $��23��6-   $��368,118,0,0q�69   $
 Wrap=�6N   # [ 5K      #��[ 5L      $	��Top=�5M      $	��120��6*   ��5J      �� *SelectedContactPersoon.Name+ . 5M   *   �� 5N   
   $
��Left=�6   $��23��6-   $��368,209,0,0q�69   $
 Wrap=�6N   # [ 5P      #��[ 5Q      $	��Top=�68   $	��120��6P   ��5O      �� * SelectedContactPersoon.Company+ . 5Q   P   �� 5R   
   $
��Left=�6   $��23��6-   $��368,253,0,0q�69   $
 Wrap=�6N   # [ 5T      #��[ 5U      $	��Top=�68   $	��120��6P   ��5S      �� *SelectedContactPersoon.City+ . 5U   P   �� 5V   
   $
��Left=�6   $��23��6-   $��368,288,0,0q�69   $
 Wrap=�6N   # [ 5X      #��[ 5Y      $	��Top=�68   $	��120��6P   ��5W      �� *SelectedContactPersoon.Email+ . 5Y   P   �� 5Z   
   $
��Left=�6   $��23��6-   $��368,321,0,0q�69   $
 Wrap=�6N   # [ 5\      #��[ 5]      $	��Top=�68   $	��120��6P   ��5[      �� *SelectedContactPersoon.Phone+ . 5]   P   �� 5^   
   $
��Left=�6   $��23��6-   $��368,354,0,0q�69   $
 Wrap=�6N   # [ 5`      #��[ 5a      $	��Top=�68   $	��120��6P   ��5_      �� *" SelectedContactPersoon.Cellphone+ . 5a   P   �� 5c   
   $
��Zoek��6q   $
��Left=�6�   $��155,121,0,0q�6�   $	��Top=�6�   $��66��6�   ��6   �� *SearchCommand+��63   ��  �� ElementName$ 	txtSearch�� �� Path$
 Text�6�   �� 5d   
   $��Bewerk��6>   $
��Left=�6O   $��576,437,0,0q�6j   $	��Top=�6   $��93��6�   $��38��6�   ��6   �� *EditContactPersonCommand+6�   5e      5f      