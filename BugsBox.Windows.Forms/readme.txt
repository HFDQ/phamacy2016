系统自定义控件与Forms常用方法扩展
1. FocusColorProvier:  
对TextBox , ComboBox, MaskedTextBox, NumericUpDown 扩展属性
ForeColor ：前景颜色
BackColor ：背景颜色
使用方法：将此控件拖到UserControl窗体中，窗体中的TextBox , ComboBox, MaskedTextBox, NumericUpDown的属性就多出可两个可扩展属性。

2. PagerControl:
分页控件。可直接拖到UserControl窗体中使用。
设置此控件的RecordCount 值，在控件的事件DataPaging 函数中获取PageIndex,PageSize,从而绑定数据。
