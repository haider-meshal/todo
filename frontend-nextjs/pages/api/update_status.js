export default async (req, res) => {
  if (!req.query.todo) {
    return res.status(400).send("todo parameter required.");
  }
  let id = encodeURI(req.query.id);
  let status = encodeURI(req.query.status);

  const url = `http://${process.env.BACKEND}:80/update_todo_status`;
  return fetch(url, {
    method: "PUT",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ id: id, status: status}),
  })
    .then((r) => r.json())
    .then((data) => {
      let result = JSON.stringify(data.result);
      return res.status(200).json(result);
    });
};
