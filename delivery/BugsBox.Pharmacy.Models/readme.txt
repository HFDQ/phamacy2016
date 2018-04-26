此类库须等luo数据库建模完成之后编写。
由luo负责变更管理。
此为entity framework 的Code First，相关细节由luo处理
几个细节要注意
1.实现须继承自Enity
2.主键在Enity中已经定义，无需定义了
3.数据字段长度，必填约束，主外键关系都要打上属性标签
4.String类库的null与非空要慎重处理
5.与主外键的导航属性添加。

//请参考
http://www.cnblogs.com/nianming/archive/2011/11/17/2252222.html




