This is a .NET Core Competency Test (API-driven Todo web application)

## Summary
This is a competency test to develope a todo application implemented according to the Event Sourcing pattern. The application has two parts: .net core backend and nextjs front end.

First, run the backend development server:

```bash
cd ToDo.API
dotnet run
```

Then, run the frontend development server:

```bash
cd frontend-nextjs
npm run dev
# or
yarn dev
```

 Open [http://localhost:8081](http://localhost:8081) and [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html) with your browser to see the result.

## Timesheet
<table>
	<thead>
		<td>
			<b>TODO</b>
		</td>
		<td>
			<b>Time Taken</b>
		</td>
		<td>
			<b>Details</b>
		</td>
	</thead>
	<tr>
		<td>Prepare dev env</td>
		<td>2 hours</td>
		<td>mac: Install .net core SDK and IDE. Unable to install vs code so will use vim instead</td>
	</tr>
	<tr>
		<td>Read about Event Sourcing pattern best practice</td>
		<td>4 hours</td>
		<td></td>
	</tr>
	<tr>
		<td>Coding backend</td>
		<td>8 hours</td>
		<td>Unable to to connect to MS sql (docker) by sql auth always login failed. Use sqlite instead until able to solve it</td>
	</tr>
	<tr>
		<td>Coding frontend</td>
		<td>4 hours</td>
		<td></td>
	</tr>
</table>

