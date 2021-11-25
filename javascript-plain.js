const args = process.argv.slice(2);

if (args[0] === '--primes' || args[0] === '-p'){
    computePrimesUpToN(+args[1])
} else {
    console.log('No maximum number provided. Aborting.')
}

function computePrimesUpToN(n){
    const primes = new Array(n).fill(true);
    primes[0] = primes[1] = false;

    const endpoint = Math.sqrt(n);
    for (let i = 2; i < endpoint; i++){
        for (let j = i*i; j < n; j += i){
            primes[j] = false;
        }
    }
    // primes.forEach((val, idx) => {if(val) console.log(idx)});
    console.log(primes.map((val, idx) => idx).filter(val => primes[val]).join(', '));
    
}