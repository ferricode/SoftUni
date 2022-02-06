function sequence2k(input) {
  let num = Number(input[0]);
  let k = 1;

  while (num >= k) {
    console.log(k);
    k = 2 * k + 1;
  }
}
sequence2k([17]);

