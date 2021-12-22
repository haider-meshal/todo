export default async (req, res) => {
  if (!req.query.todo) {
    return res.status(400).send("todo parameter required.");
  }
  let id = encodeURI(req.query.id);
  let todo = encodeURI(req.query.todo);

  const url = `http://${process.env.BACKEND}:8080/update_todo`;
  return fetch(url, {
    method: "PUT",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ id: id, todo: todo}),
  })
    .then((r) => r.json())
    .then((data) => {
      let result = JSON.stringify(data.result);
      return res.status(200).json(result);
    });
};
