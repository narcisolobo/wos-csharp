/* 
This demonstrates how the call stack works without recursion. The call stack is
used when any function executes another function because the outer function
has to wait for the nested function to be done before the outer function can
complete. The call stack is used to go back and resume execution of the outer
function when the nested function is finishes.
*/

function first(n) {
  console.log(
    `ƒ'first'  is being executed and has been pushed into the call stack.`
  );
  // Before 'first' can finish, it needs to wait for second() to finish.
  const secondResult = second(n + 1);
  console.log(
    `ƒ'second' returned the value: ${secondResult}.   ƒ'second' was popped out of the call stack.`
  );
  /* 
  return signals the function is done and can be removed from the stack so the
  next function in the stack can be resumed if there was a function waiting for
  the current function to finish. Functions without a return will return
  undefined at the end.
  */
  return 'one';
}

function second(n) {
  console.log(
    `ƒ'second' is being executed and has been pushed into the call stack.`
  );
  // Before 'second' can finish, it needs to wait for third() to finish.
  const thirdResult = third(n + 1);
  console.log(
    `ƒ'third'  returned the value: ${thirdResult}. ƒ'third' was popped out of the call stack.`
  );
  return 'two';
}

function third(n) {
  console.log(
    `ƒ'third'  is being executed and has been pushed into the call stack.`
  );
  return 'three';
}

const firstResult = first(1);
console.log(
  `ƒ'first'  returned the value: ${firstResult}.   ƒ'first' was popped out of the call stack.`
);

/* 
  The above logs print in the order shown below. Notice the order of execution is
  one -> two -> three, but the order of returning is
  three -> two -> one because the first function can't finish until the second
  function finishes and the second function can't finish until the third function
  finishes.

  ƒ'first'  is being executed and has been pushed into the call stack.
  ƒ'second' is being executed and has been pushed into the call stack.
  ƒ'third'  is being executed and has been pushed into the call stack.
  ƒ'third'  returned the value: three. ƒ'third' was popped out of the call stack.
  ƒ'second' returned the value: two.   ƒ'second' was popped out of the call stack.
  ƒ'first'  returned the value: one.   ƒ'first' was popped out of the call stack.
*/
