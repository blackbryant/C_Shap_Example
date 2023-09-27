#
Any support for Database Frameworks/ORMs?
AutoMapper.Data: ADO.NET Support
Map from IDataReader

AutoMapper.EF6: Extension Methods for EF6
Async extension methods for ProjectTo

AutoMapper.Collection: Map collections by means of equivalency
EqualityComparision between 2 classes

Add, map to, and delete items in a collection by comparing items for matches

AutoMapper.Collection.EF to support Equality by Primary Keys

Persist methods to handle Insert/Update/Delete DTOs to the Entities

ExpressionMapping: Map Linq Expressions
Useful with OData

#安裝AutoMapper

#AutoMapper
使用表達式來運算，速度會比反射快

#範例
1. AutoMapperEx00.cs : 單筆/多筆相同屬性的資料Mapping 、多個物件Map匹配設定、將MapperConfiguration改由Profile定義，好處分模組去定義

2. AutoMapperEx01.cs : 差異Mappging， 對象屬性不一定互相可以匹配。

3. AutoMapperEx02.cs :驗證分為兩邊檢查、源頭檢查、目的檢查

4.AutoMapperEx03.cs :反轉映射、列表與數組

5. AutoMapperEx04.cs :嵌套映射、自訂義型轉換器:就是來源物件與目的物件屬性不相同

6.  AutoMapperEx04.cs : 投影例如將日期類型轉換成年、月、日
