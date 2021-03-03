IndexBasedIoc is a different take on tradional ioc frameworks. By creating an index file we dont need fancy lookups, like converting hashcodes to an index(hashsets, dictionaries).

**fastest ioc framework**


### Explantions
**First value**: Time of single-threaded execution in [ms]  
**Second value**: Time of multi-threaded execution in [ms]  
**_*_**: Benchmark was stopped after 1 minute and result is extrapolated.  
### Basic Features
|**Container**|**Singleton**|**Transient**|**Combined**|**Complex**|
|:------------|------------:|------------:|-----------:|----------:|
|**IndexBasedIoc**|**8**<br/>**27**|**22<br/>39**|**39<br/>56**|70<br/>**64**|
|**No**|41<br/>49|49<br/>59|69<br/>76|99<br/>103|
|**[abioc 0.8.0](https://github.com/JSkimming/abioc)**|26<br/>43|3<br/>56|51<br/>82|**67**<br/>78|
|**[Autofac 6.1.0](https://github.com/autofac/Autofac)**|702<br/>499|882<br/>597|2369<br/>1492|7249<br/>4391|
|**[Caliburn.Micro 1.5.2](https://github.com/Caliburn-Micro/Caliburn.Micro)**|465<br/>270|533<br/>322|1583<br/>906|7403<br/>3712|
|**[Catel 5.12.11](http://www.catelproject.com)**|232<br/>282|3883<br/>4263|9072<br/>9828|21140<br/>22450|
|**[DryIoc 4.7.2](https://github.com/dadhi/DryIoc)**|61<br/>58|93<br/>79|93<br/>111|115<br/>115|
|**[DryIocZero 4.0.0](https://github.com/dadhi/DryIoc)**|110<br/>96|88<br/>89|98<br/>105|220<br/>169|
|**[Dynamo 3.0.2](http://martinf.github.io/Dynamo.IoC)**|95<br/>70|104<br/>86|207<br/>158|685<br/>381|
|**[Grace 7.2.0](https://github.com/ipjohnson/Grace)**|29<br/>**39**|42<br/>59|58<br/>81|77<br/>82|
|**[Lamar 5.0.0](https://jasperfx.github.io/lamar/)**|70<br/>70|163<br/>87|100<br/>115|129<br/>118|
|**[LightInject 6.4.0](https://github.com/seesharper/LightInject)**|46<br/>47|45<br/>57|88<br/>99|153<br/>143|
|**[Maestro 3.6.5](https://github.com/JonasSamuelsson/Maestro)**|410<br/>312|404<br/>307|652<br/>477|1547<br/>1204|
|**[Mef 4.0.0.0](https://github.com/MicrosoftArchive/mef)**|22679<br/>11820|37640<br/>25052|57462<br/>68730*|112712*<br/>131716*|
|**[Mef2 5.0.0.0](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|259<br/>178|252<br/>192|355<br/>263|657<br/>444|
|**[MicroResolver 2.3.5](https://github.com/neuecc/MicroResolver)**|25<br/>39|34<br/>59|55<br/>77|92<br/>89|
|**[Microsoft Extensions DependencyInjection 5.0.1](https://github.com/aspnet/Extensions)**|73<br/>67|103<br/>86|126<br/>115|146<br/>120|
|**[Microsoft.VisualStudio.Composition 16.4.11](https://blogs.msdn.com/b/bclteam/p/composition.aspx)**|9074<br/>4916|13891<br/>9399|19760<br/>14962|57910<br/>51972|
|**[Mugen MVVM Toolkit 6.5.0](https://github.com/MugenMvvmToolkit/MugenMvvmToolkit)**|102<br/>138|409<br/>715|2052<br/>2590|9348<br/>11352|
|**[MvvmCross 7.1.2](https://github.com/MvvmCross/MvvmCross)**|240<br/>281|1470<br/>1585|3607<br/>4008|10040<br/>11160|
|**[Ninject 3.3.4](http://ninject.org)**|3473<br/>2563|8686<br/>6969|23529<br/>17635|63579*<br/>49285|
|**[Rezolver 2.1.0](http://rezolver.co.uk)**|121<br/>100|137<br/>126|194<br/>171|328<br/>238|
|**[SimpleInjector 5.2.1](https://simpleinjector.org)**|58<br/>66|78<br/>84|124<br/>114|152<br/>116|
|**[Singularity 0.18.0](https://github.com/Barsonax/Singularity)**|24<br/>39|39<br/>59|66<br/>82|76<br/>84|
|**[Spring.NET 2.0.1](http://www.springframework.net/)**|950<br/>987|9711<br/>11447|26941<br/>23873|74745*<br/>57777|
|**[Stashbox 3.5.0](https://github.com/z4kn4fein/stashbox)**|35<br/>42|63<br/>69|69<br/>96|86<br/>86|
|**[StructureMap 4.7.1](http://structuremap.net/structuremap)**|1121<br/>717|1281<br/>856|3410<br/>2166|8312<br/>6052|
|**[Unity 5.11.10](https://github.com/unitycontainer/unity)**|216<br/>148|1443<br/>835|3326<br/>1995|9503<br/>4739|
|**[Windsor 5.1.1](http://castleproject.org)**|461<br/>333|1839<br/>1127|8062<br/>5972|19313<br/>13001|
|**[ZenIoc 1.0.1](https://github.com/zenmvvm/ZenIoc)**|306<br/>198|267<br/>188|674<br/>440|1809<br/>1103|
|**[Zenject 8.0.0](https://github.com/modesttree/Zenject)**|479<br/>448|1370<br/>1070|3689<br/>3065|11142<br/>10106|
### Machine
The benchmark was executed on the following machine:  
**CPU**: Intel(R) Core(TM) i5-6260U CPU @ 1.80GHz  
**Memory**: 15,89GB
