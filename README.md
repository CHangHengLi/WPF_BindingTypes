# BindingTypesDemo

WPF 绑定资源类型演示项目，基于 .NET Core 8.0。
![image](https://github.com/user-attachments/assets/558f80df-470a-44cd-a520-e93d7df23f88)

## 项目描述

此项目演示了 WPF 应用程序中的各种绑定资源类型：

- 元素绑定（ElementName）
- 相对源绑定（RelativeSource）
- 静态资源绑定（StaticResource）
- 动态资源绑定（DynamicResource）
- 数据上下文（DataContext）

项目采用 MVVM（Model-View-ViewModel）设计模式，通过一个用户管理系统的界面直观展示各种绑定方式。

## 运行说明

### 直接运行

在当前项目目录下执行：

```
dotnet run
```

### 使用 Visual Studio

打开当前目录下的 `BindingTypesDemo.sln` 解决方案文件，按 F5 运行。

## 主要功能

- 用户列表展示与管理
- 用户详情编辑
- 主题切换
- 高级/基本视图切换

## 目录结构

- `Models/`: 数据模型
- `ViewModels/`: 视图模型
- `Converters/`: 值转换器
- `Commands/`: 命令实现

## 学习重点

本项目中可以学习以下 WPF 绑定知识点：

1. 如何在元素之间使用 ElementName 绑定
2. 如何使用 RelativeSource 实现 Self、FindAncestor 和 TemplatedParent 绑定
3. 如何使用和切换静态/动态资源
4. 如何在 MVVM 模式下设置和使用 DataContext 
