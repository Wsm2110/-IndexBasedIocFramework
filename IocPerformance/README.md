# Ioc Performance

[![Build Status](https://dev.azure.com/danielpalme/IocPerformance/_apis/build/status/danielpalme.IocPerformance?branchName=master)](https://dev.azure.com/danielpalme/IocPerformance/_build/latest?definitionId=6&branchName=master)

Source code of my performance comparison of the most popular .NET IoC containers:  
[www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison](https://www.palmmedia.de/Blog/2011/8/30/ioc-container-benchmark-performance-comparison)

Author: Daniel Palme  
Blog: [www.palmmedia.de](https://www.palmmedia.de)  
Twitter: [@danielpalme](https://twitter.com/danielpalme)  

## Results
### Explantions
**First value**: Time of single-threaded execution in [ms]  
**Second value**: Time of multi-threaded execution in [ms]  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**ä 1**|**10**<br/>**72**|**24**<br/>**78**|**70**<br/>**102**|**97**<br/>**135**|
### Advanced Features
|**Container**|
|:------------|
|**ä 1**|
### Prepare
|**Container**|**Prepare And Register And Simple Resolve**|**Prepare And Register**|
|:------------|------------------------------------------:|-----------------------:|
|**ä 1**|**9092**<br/>|**6800**<br/>|
### Charts
![Basic features](https://www.palmmedia.de/blogimages/5225c515-2f25-498f-84fe-6c6e931d2042.png)
![Advanced features](https://www.palmmedia.de/blogimages/e0401485-20c6-462e-b5d4-c9cf854e6bee.png)
![Prepare](https://www.palmmedia.de/blogimages/67b056a5-9da8-40b4-9ae6-0c838cdac180.png)
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-4460  CPU @ 3.20GHz  
**Memory**: 7.95GB
