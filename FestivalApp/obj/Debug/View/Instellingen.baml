   M S B A M L   `   `   `  ����F  BFestivalApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FestivalApp.ViewModelFestivalApp.ViewModel  5      #    FestivalApp.View.Instellingen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2vm#clr-namespace:FestivalApp.ViewModel     5        � 	Resources  5	         TextboxError �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value  ErrorTemplate  GenreTemplate  StageTemplate  ContactPersonTypeTemplate��%s  &	        &	 �     &	 6    &	 �    &	 �    �� 5
   
   " ��6%    5      P� 5       �@=�HasError . . �5      ��  � ��
 �  ��63   5      5      �� 5   
   .R�5      �� .+�5      �� 
���  ����6-   �� *[0].ErrorContent+�� 5      
���  ��$��2q�6+   ._�5      �� 5      5      5      �� 5   
   .R�5      �� .+�5      �� ��6   �� *Name+5      5       �� 5!   
   .R�5"      �� .+�5#      �� ��6   �� *Name+5$      5%      �� 5&   
   .R�5'      �� .+�5(      �� ��6   �� *Name+5)      5*      5+      .��5,      �  � DataContext 5-   
   *  $FestivalApp.ViewModel.InstellingenVM  5.      .+�50   
   �� $��Instellingen��6   $
��Left=�6'   $��26,25.5,0,0q�6B   $	��Top=�6W   $��24(�6o   �� 51   
   $��Type personen��6   $
��Left=�6(   $��26,88.5,0,0q�6C   $	��Top=�6X   $��18.667(�6p   �� 52   
   $��Genres
��6   $
��Left=�6+   $��
26,363,0,0q�6F   $	��Top=�6Z   $��18.667(�6r   $��35.657��6�   $��131.637��6�   �� 53   
   $
��Left=�6   $��23��6-   $��240,128.33,0,0q�69    �� TextWrapping$
 Wrap=�6Q   	 =� ErrorTemplate#	 [ 55      #��[  56      $	��Top=�57      $	��120��6*   ��54      �� *SelectedContactPerson.Name+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� ValidatesOnDataErrors . 57   *   �� 58   
   #��[ 6=   $
��Left=�6�   $	��215��6�   $��26,128.33,0,0q�6�   $	��Top=�6�   $	��183��6�   ��6   �� *ContactPersonTypes+ �� SelectedItem 6w   �� *SelectedContactPerson+6�   �� 59   
   #��[ 61   $
��Left=�6�   $	��215��6�   $��26,403.657,0,0q�6�   $	��Top=�6�   $	��183��6�   ��6   �� *Genres+ 6_   �� *SelectedGenre+6�   �� 5:   
   $	��New��6A   $
��Left=�6O   $��240,166,0,0q�6j   $	��Top=�6   $��75��6�   ��6   �� *AddContactPersonTypeCommand+6�   �� 5;   
   $��Verwijderen��6D   $
��Left=�6Z   $��240,242.5,0,0q�6u   $	��Top=�6�   $��75��6�   ��6   �� * DeleteContactPersonTypeCommand+6�   �� 5<   
   $��Opslaan��6B   $
��Left=�6T   $��240,203.5,0,0q�6o   $	��Top=�6�   $��75��6�   ��6   �� *SaveContactPersonTypeCommand+6�   �� 5=   
   $
��Left=�6   $��23��6-   $��240,411.83,0,0q�69   $
 Wrap=�6Q   #	 [ 5?      #��[  5@      $	��Top=�5A      $	��120��6*   ��5>      �� *SelectedGenre.Name+$
 PropertyChanged=� . 5A   *   �� 5B   
   $	��New��65   $
��Left=�6C   $��240,449.5,0,0q�6^   $	��Top=�6u   $��75��6�   ��6   �� *AddGenreCommand+6�   �� 5C   
   $��Verwijderen��68   $
��Left=�6N   $��240,526,0,0q�6i   $	��Top=�6~   $��75��6�   ��6   �� *DeleteGenreCommand+6�   �� 5D   
   $��Opslaan��66   $
��Left=�6H   $��240,487,0,0q�6c   $	��Top=�6x   $��75��6�   ��6   �� *SaveGenreCommand+6�   �� 5E   
   $��Podia
��6   $
��Left=�6%   $��435,363,0,0q�6@   $	��Top=�6U   $��18.667(�6m   $��36��6   $	��132��6�   �� 5F   
   #��[ 62   $
��Left=�6�   $	��215��6�   $��435,404,0,0q�6�   $	��Top=�6�   $	��184��6�   ��6   �� *	Podiums+ 6`   �� *SelectedStage+6�   �� 5G   
   $
��Left=�6   $��23��6-   $��649,412,0,0q�69   $
 Wrap=�6N   #	 [ 5I      #��[  5J      $	��Top=�5K      $	��120��6-   ��5H      �� *SelectedStage.Name+ . 5K   -   �� 5L   
   $	��New��65   $
��Left=�6C   $��649,450,0,0q�6^   $	��Top=�6s   $��76��6�   ��6   �� *AddStageCommand+6�   �� 5M   
   $��Verwijderen��68   $
��Left=�6N   $��649,526,0,0q�6i   $	��Top=�6~   $��76��6�   ��6   �� *DeleteStageCommand+6�   �� 5N   
   $��Opslaan��66   $
��Left=�6H   $��649,487,0,0q�6c   $	��Top=�6x   $��76��6�   ��6   �� *SaveStageCommand+6�   �� 5O   
   $��Festival Data
��6   $
��Left=�6-   $��432,110,0,0q�6H   $	��Top=�6]   $��18.667(�6u   $��36��6�   $	��132��6�   �� 5P   
   $
��Van:��6   $
��Left=�6   $��446,160,0,0q�6:   $	��Top=�6O   �� 5Q   
   $
��Tot:��6   $
��Left=�6   $��446,198,0,0q�6:   $	��Top=�6O   �� 5R   
   $
��Left=�6   $��22��6-   $��446,236,0,0q�69   $
 Wrap=�6N   $��FestivalNaam��6b   $	��Top=�6v   $	��120��6�   �� 5S   
   $��Bevestig��69   $
��Left=�6L   $��446,274,0,0q�6g   $	��Top=�6|   $	��120��6�   $��40��6�   ��6   �� *AddFestivalCommand+6�   (  "System.Windows.Controls.DatePicker  5T   
   -   5          Name$ VanDatum��5T   :   $
��Left=�6L   $��517,160,0,0q�6g   $	��Top=�6|      SelectedDate 6   �� *
BeginDatum+6|     5U   
   -   5        $ TotDatum��5U   8   $
��Left=�6J   $��517,194,0,0q�6e   $	��Top=�6z    6   �� *	EindDatum+6z   �� 5V   
   $��Bewerk��6B   $
��Left=�6S   $��240,274,0,0q�6n   $	��Top=�6�   $��75��6�   ��6   �� *EditContactPersonTypeCommand+6�   �� 5W   
   $��Bewerk��66   $
��Left=�6G   $��240,564,0,0q�6b   $	��Top=�6w   $��75��6�   ��6   �� *EditGenreCommand+6�   �� 5X   
   $��Bewerk��66   $
��Left=�6G   $��649,564,0,0q�6b   $	��Top=�6w   $��75��6�   ��6   �� *EditStageCommand+6�   5Y      5Z      