ergebnisse = read.csv2("bin\\Release\\results.csv", colClasses = c(rep('integer', 2),rep('numeric',6)))
size = ergebnisse$Size
colnames(ergebnisse) = c("Size", "Iteration", "InitTran", "InitBatch", "InitInc", "MainTran", "MainBatch", "MainInc")
egAvg = aggregate(ergebnisse[,3:8],list(size),mean)

size = egAvg[,1]
tran = (egAvg[,5]-egAvg[,2])/1000
batch = (egAvg[,6]-egAvg[,3])/1000
inc = (egAvg[,7]-egAvg[,4])/1000

pdf(file="..\\img\\results.pdf", width=6, height=3)
par(mar=c(4.3,4.0,0.3,0.3))
plot(size, batch, type="n", xlab="Number of states", ylab="Runtime for 100 changes [s]")
lines(size, tran, col="blue")
points(size, tran, pch=16, col="blue")
lines(size, batch, col="red")
points(size, batch, pch=2, col="red")
lines(size, inc, col="purple")
points(size, inc, pch=8, col="purple")
legend(10, 4, c("NMF Transformations", "NMF Synchronizations (Batch)", "NMF Synchronizations (Incremental)"), col=c('blue', 'red', 'purple'), pch=c(16,2, 8), bty='n', lty=1)
dev.off()