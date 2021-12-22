export default async (req, res) => {
  if (!req.query.todo) {
    return res.status(400).send("todo parameter required.");
  }
  let todo = req.query.todo;
  const url = `http://${process.env.BACKEND}:8080/create_todo`;
  return fetch(url, {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ todo: todo, status: 0}),
  })
    .then((r) => r.json())
    .then((data) => {
      let result = JSON.stringify(data.result);
      return res.status(200).json(result);
    });
};
