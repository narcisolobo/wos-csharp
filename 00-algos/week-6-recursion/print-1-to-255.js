function print1To255(i = 1) {
  if (i > 5) {
    return;
  }

  console.log(i);

  return print1To255(i + 1);
}

print1To255();
