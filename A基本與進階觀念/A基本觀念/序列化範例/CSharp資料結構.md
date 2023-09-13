
###  陣列型態
Array: 連續空間分配，而且元素是一樣，刪除得比較慢，讀取比較快，可以指定索引訪問
ArrayList: 不固定長度，連續空間分配，
List: 也是Array內存是連續擺放，泛型，保證類型安全，刪除得比較慢，讀取比較快


###  串列型態
LinkedList : 泛型，鏈表空間不連續分配，每個元素都有紀錄前後節點
                     缺點: 找元素只能重頭開始。優點:刪除容易
Queue: 鏈表，先進先出，泛型
Stack: 先進後出，Push,Pull,Peak
SortedList : 不可以重複新增，會出現錯誤

### 雜湊表(集合)
HashSet :去重複
SortedSet:去重複+排序


###Key-Value 超過一萬
HashTable: Key-Value型式，查找/刪除/修改一次定位，數據太多，重複定位效率差，線程安全
Dictionary<Object,Object>:泛型,Key-Value型式，查找/刪除/修改快，有序的，數據太多，重複定位效率差
SortedDictionary<Object,Object> : 會根據key來排序

####線程安全
ConcurrentQueue:
ConcurrentStack:
ConcurrentBag:
ConcurrentDictionary:
BlockingCollection:

#
IEnumrable<string> :傳入為表達是委託，迭代器，真的要查詢才執行
IQueryable<string> :傳入為表達是目錄樹解析，延遲編譯才執行，EF延遲查詢



