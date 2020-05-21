//Exercise1
const promiseRandom = new Promise(resolve => {
    setTimeout(() => resolve(Math.floor(Math.random() * 10) + 1), 3000);
});
promiseRandom.then(
    result => console.log("The random number is : " + result),
    error => console.error("error")
);

//Exercise2
const words = ["i", "am", "cat"];
function sortWords(words) {
    return words.sort();
}
function makeAllCaps(words) {
    const capWords = [];
    for (let i = 0; i < words.length; i++) {
        capWords.push(words[i].toUpperCase());
    }
    return new Promise(resolve => resolve(capWords), reject => reject(new Error("error")));
}
const promise = makeAllCaps(words);
promise.then(
    capWords => console.log(sortWords(capWords)),
    error => console.error(error.message)
);
// promise.catch(console.error(error.message));