export default async (req, res) => {
  if (!req.query.todo) {
    return res.status(400).send("todo parameter required.");
  }

  let id = encodeURI(req.query.todo);
  const url = `http://${process.env.BACKEND}:8080/delete_todo?id=${id}`;
  return fetch(url, {
    method: "DELETE",
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    }
  })
    .then((r) => r.json())
    .then((data) => {
      let result = JSON.stringify(data.result);
      return res.status(200).json(result);
    });
};
