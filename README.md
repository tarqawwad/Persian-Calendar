# Persian-Calendar 
- Use JS,Html,CSS,C#
- White theme for Persian Calendar , easy to use.
- Create Persian Calendar as html helper.
- Use Tag builder in c# for build html helper (MVCHtmlString).
- Convert selected persian date to gregorian date.
- Cannot allow to edit on inputs. 
- Create Random ID for Inputs and Calendar. 


# Options 

- (string) componentName : name is applied on gregorian date ( when get value for component name , return gregorian date ).
- (Datetime) value : set value for calendar.
- (object) htmlattribute : Add custom attributes to the input that is used for the calendar.
- (string) onChange : Apply any script on change the value on Calendar such as `function(){ //any thing }` .
- (bool) IsRequired : Are you date is required ? true or false . 
- (Datetime) minValue : Select minimum value for calendar . 
- (Datetime) maxValue : Select maximum value for calendar . 


# How to use 

- add component namespace ` <add namespace="PersianCalendarComponents.Components" />` to "Views/Web.config" 
- call DatePicker from any View such as : 

`@Html.TADatePicker(componentName,value, htmlattribute,onChange, IsRequired, minValue, maxValue)`

# ScreenShot Calendar

![Screenshot_1](https://user-images.githubusercontent.com/63288936/152077292-8879594f-21f4-4e67-8fa1-b8959b7609f4.png)
![Screenshot_4](https://user-images.githubusercontent.com/63288936/152077298-dbe7343f-b344-465c-a1a0-94b91d5c9980.png)
![Screenshot_5](https://user-images.githubusercontent.com/63288936/152077302-9f1e77f9-e949-42e4-a5dc-7b9a5dcee3e1.png)
