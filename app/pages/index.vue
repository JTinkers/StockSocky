<template>
	<v-container fluid>
		<v-row>
			<v-col cols='2'>
				<v-text-field v-model='search' outlined placeholder='Search..'/>
			</v-col>
		</v-row>
		<v-data-table :search='search' :items='stocks' :headers='headers'/>
	</v-container>
</template>

<script>
	export default
	{
		data: () =>
		({
			search: null,
			stocks: []
		}),
		mounted()
		{
			this.fetch()
		},
		computed:
		{
			headers()
			{
				var headers =
				[
					{
						text: 'Symbol',
						value: 'symbol'
					},
					{
						text: 'Quantity',
						value: 'quantity'
					},
					{
						text: 'Invested Value',
						value: 'investedValue'
					},
					{
						text: 'Market Value',
						value: 'marketValue'
					},
					{
						text: 'Est. Profit',
						value: 'estimatedProfit'
					}
				]

				return headers
			}
		},
		methods:
		{
			async fetch()
			{
				var { data } = await this.$axios.get('/api/stocks')

				this.stocks = data
			}
		}
	}
</script>
