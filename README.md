# MiZoneCommerce

## Based on DotNetCore 5.0
#### Framework Design
using Autofac instead Core IOC.
using Log4Net to save local log.
using ali OSS and local sotrage. easy switch.
using jwt Authorize
Hot swap plugin
using mvc and webapi at same time
built-in from validate plugin.plug and play
build in websocket
action level Authorize check
using areas mode when using mvc model
using dapper to connect database
using swagger api document
global error catch
build-in wechat plugin
pluggable webapi modular design


### 基于.net 5.0搭建
#### 架构设计
- 使用Autofac替代自带ioc框架实现工厂模式
- 添加Log4Net自动日志
- 内置阿里OSS和DotNet本地存储
- 使用JWT进行权限认证
- 插件热拔插设计
- 同时保留传统MVC和WebApi
- 封装form提交插件 无需手动验证表单 自动添加Loading
- 集成简单Websocket功能 可实现分组聊天
- 集成精确到标签的权限认证
- 系统添加区域 Admin Web Mobile (工作在MVC模式)
- 系统使用Dapper以及Linq扩展库
- 配置Swagger文档
- 全局异常捕捉
- 集成Senparc微信库


#### 引用
- WeihanLi.AspNetMvc.AccessControlHelper
- AdminLTE

