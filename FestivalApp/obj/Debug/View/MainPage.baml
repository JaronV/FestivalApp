   M S B A M L   `   `   `  ����F  BFestivalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FestivalApp.ViewModelFestivalApp.ViewModel  5          FestivalApp.View.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2vm#clr-namespace:FestivalApp.ViewModel     5      X TXceed.Wpf.Toolkit, Version=1.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      $��772.5��5   4     � 	Resources  5	         scStageTemplate �� RelativeSource �� AncestorType  scBandTemplate  
ItemSPanel  DeleteContact �� StringFormat��%�  &	        &	 `    &	 �    �� 5   
   .R�5      � $��10q�6   .+�5      �� $��Center=�62   $��0,0,5,0q�6M   ��6   �� *Name+6M   �� 5      $��Delete��6   ��6*   �� * DataContext.DeleteStageCommand+ �� " >���6�   �� *ID+�� 5      $��20,0,0,0q�6   #���  61   #���  6   ��6a   �� *Bands+5      5      5      �� 5   
   .R�5      � 5      5      �� 5   
   .R�5      �� ���	#FF007BB2$��1q�6-   $��2q�6A   ._�5      �� ���	#FF19B8FF��64   �� *
TimeSpan+.+�5      �� #���  6   $��Right=�6E   $��X��6a   ��6m   �� *)'DataContext.DeleteBandFromLineUpCommand+ �� " >���6�   �� *ID+�� 5      ��6    �� *	band.Name+�� 5      �� 5       �6   �� *From+$ HH:mm�� �� 5!      $�-��6    �� 5"      �6   �� *Until+$ HH:mm��5#      �� 5$      ��6    �� *Stage+5%      5&      5'      5)      .��5*      � $��0q�6    � RowDefinitions 5+   
   �� 5,      $��68 �6   6*   �� 5-      $��* �6    � ColumnDefinitions 5/   
   �� 50      $��5* �6   �� 51      $
��251* �6    � DataContext 53   
   &   FestivalApp.ViewModel.MainPageVM  54      .+�59   
   �� #��[  6<   $��11,10,0,415q�6l   $��1��6�   $��1��6�   ��6   �� *StagesPerDag+6�   �� 5:   
   -   5         ��Name$ 	lblLineUp��5:      $��Line Up��6$   $
��Left=�66   $��1,25,0,0q�6Q   $	��Top=�6c   $��47��6{   $	��163��6�   $��24(�6�   $��2��6�   $��1��6�   �� 5;   
   $��Line Up configuratie��6   $
��Left=�6/   $��	1,284,0,0q�6J   $	��Top=�6]   $��34��6u   $	��201��6�   $��22(�6�   $��1��6�   $��1��6�   �� 5<   
   $
��Band��6   $
��Left=�6   $��	0,354,0,0q�6:   $	��Top=�6M   $��28��6e   $	��114��6q   $��1��6}   $��1��6�   �� 5=   
   $��Podium��6   $
��Left=�6!   $��40��6<   $��	0,387,0,0q�6H   $	��Top=�6[   $	��128��6s   $��1��6   $��1��6�   �� 5>   
   $	��Dag��6   $
��Left=�6   $��22��69   $��	0,427,0,0q�6E   $	��Top=�6X   $��84��6p   $��1��6{   $��1��6�   �� 5?   
   $��	Begin Uur��6   $
��Left=�6$   $��31��6?   $��	0,474,0,0q�6K   $	��Top=�6^   $	��110��6v   $��1��6�   $��1��6�   �� 5@   
   $��Eind uur��6   $
��Left=�6#   $��	0,525,0,0q�6>   $	��Top=�6Q   $��43��6i   $	��104��6u   $��1��6�   $��1��6�   �� 5A   
    �� DisplayMemberPath$
 Name��61   $
��Left=�6p   $��
89,352,0,0q�6�   $	��Top=�6�   $	��120��6�   $��21��6�   $��1��6�   $��1��6�   ��6   �� *Bands+	 �� SelectedItem	 6J   �� *LineUp.band+6�   �� 5B   
   $
 Name��63   $
��Left=�6s   $��
89,387,0,0q�6�   $	��Top=�6�   $	��120��6�   $��20��6�   $��1��6�   $��1��6�   ��6   �� *	Podiums+	 6L   �� *LineUp.stage+6�   �� 5C   
   $
 Date��67   
 �� ItemStringFormat$
 
dd/MM/yyyy��6P   $
��Left=�6�   $��
89,427,0,0q�6�   $	��Top=�6�   $	��120��6�   $��22��6�   $��1��6�   $��1��6   ��6   �� *UniekeDagen+	 6n   �� *LineUp.Date+6   �� 5D   
   $��Selecteer een dag��6   $��257,356,647,317q�6.   $��1��6G   $��1��6T   �� 5E   
   $
 
dd/MM/yyyy��68   $
 Date��6V   $��382,354,514,317q�6�   $��1��6�   $��1��6�   ��6   �� *UniekeDagen+	 6p   �� *SelectedDag+6�   &   Xceed.Wpf.Toolkit.DateTimeUpDown  5F   
      Format$ Custom=�6      FormatString$ HH:mm��6.   $��89,472,768,199q�6�   $��1��6�   $��1��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6C   �� *LineUp.From+ �� UpdateSourceTrigger$ 	LostFocus=�6�     5G   
   $ Custom=�6   $ HH:mm��6.   $��89,510,768,158q�6�   $��1��6�   $��1��6�    6C   �� *LineUp.Until+$ 	LostFocus=�6�   �� 5I   
   $��Opslaan��6   $��89,570,683,87q�6I   $��1��6`   $��1��6m   ��6#   �� *SaveLineUpCommand+6m   5N      5O      